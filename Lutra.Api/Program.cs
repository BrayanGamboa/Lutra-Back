using Lutra.Application.Auth.UseCases.Login;
using Lutra.Application.Auth.UseCases.Register;
using Lutra.Application.Auth.UseCases.Role;
using Lutra.Application.Auth.UseCases.RoleUsersDetail;
using Lutra.Application.Auth.UseCases.User;
using Lutra.Application.Catalog;
using Lutra.Application.Inventory;
using Lutra.Application.Products;
using Lutra.Application.Sales;
using Lutra.Application.Customers;
using Lutra.Api.Extensions;
using Lutra.Api.Middleware;
using Lutra.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// JWT autenticación
var jwtSection = builder.Configuration.GetSection("Jwt");
var secret = jwtSection["Secret"] ?? throw new InvalidOperationException("Jwt:Secret not configured");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSection["Issuer"],
            ValidAudience = jwtSection["Audience"],
            IssuerSigningKey = key
        };
    });

builder.Services.AddAuthorization();

// Swagger / Swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lutra API", Version = "v1", Description = "API de gestión Lutra" });
    c.EnableAnnotations();

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Bearer token. Example: Bearer {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { securityScheme, Array.Empty<string>() } });
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<RegisterUseCase>();
builder.Services.AddScoped<RoleUseCase>();
builder.Services.AddScoped<UserUseCase>();
builder.Services.AddScoped<RoleUsersDetailUseCase>();
builder.Services.AddScoped<GetAllUsersUseCase>();

builder.Services.AddCatalogUseCases();
builder.Services.AddInventoryApplication();
builder.Services.AddProductApplication();
builder.Services.AddSalesApplication();
builder.Services.AddCustomersApplication();

var DomainsAllow = "_DomainsAllow";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DomainsAllow,
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});


var app = builder.Build();

// Midedleware para manejo global de excepciones
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lutra API v1"));

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(DomainsAllow);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

await app.ApplyDatabaseMigrationsAsync();
app.Run();
