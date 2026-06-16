using Lutra.Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", "auth");
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.UserId).HasColumnName("user_id");
            entity.Property(u => u.Username).HasColumnName("user_name").HasMaxLength(50).IsRequired();
            entity.Property(u => u.Email).HasColumnName("email").HasMaxLength(150).IsRequired();
            entity.Property(u => u.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
            entity.Property(u => u.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            entity.Property(u => u.LastName).HasColumnName("lastname").HasMaxLength(100).IsRequired();
            entity.Property(u => u.CreatedAt).HasColumnName("create_at");
            entity.Property(u => u.UpdatedAt).HasColumnName("update_at");
            entity.Property(u => u.LastLoginAt).HasColumnName("last_login_at");
            entity.Property(u => u.IsActive).HasColumnName("is_active").IsRequired();

            entity.HasIndex(u => u.Username).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
        });
    }
}
