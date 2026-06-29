using Lutra.Application.Auth.UseCases.Login;
using Lutra.Application.Auth.UseCases.Register;
using Lutra.Api.Extensions;
using Lutra.Infrastructure;
using Lutra.Application.Auth.UseCases.Role;
using Lutra.Application.Auth.UseCases.RoleUsersDetail;
using Lutra.Application.Auth.UseCases.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<RegisterUseCase>();
builder.Services.AddScoped<RoleUseCase>();
builder.Services.AddScoped<UserUseCase>();
builder.Services.AddScoped<RoleUsersDetailUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

await app.ApplyDatabaseMigrationsAsync();
app.Run();
