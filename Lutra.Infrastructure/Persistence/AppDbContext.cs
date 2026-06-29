using Lutra.Domain.Auth;
using Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleUsersDetail> UserRoles => Set<RoleUsersDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_roles");

            entity.ToTable("roles", "auth");

            entity.Property(e => e.RoleId).HasDefaultValueSql("nextval('auth.seq_roles'::regclass)").HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<RoleUsersDetail>(entity =>
        {
            entity.HasKey(e => e.RoleUserDetailId).HasName("pk_role_users_detail");

            entity.ToTable("role_users_detail", "auth");

            entity.Property(e => e.RoleUserDetailId).HasDefaultValueSql("nextval('auth.seq_role_users_detail'::regclass)")
            .HasColumnName("role_user_detail_id");
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone").HasColumnName("update_at");
            entity.Property(e => e.RoleId)
                .HasColumnName("role_id");
            entity.Property(e => e.UserId)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleUsersDetails)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_users_detail_roles_role_id");

            entity.HasOne(d => d.User).WithMany(p => p.RoleUsersDetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_users_detail_users_user_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_users");

            entity.ToTable("users", "auth");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever().HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_at"); ;
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp without time zone")
            .HasColumnName("update_at");
            entity.Property(e => e.Email).HasMaxLength(150).HasColumnName("email");
            entity.Property(e => e.IsActive).HasDefaultValue(true).HasColumnName("is_active");
            entity.Property(e => e.LastName).HasMaxLength(100).HasColumnName("lastname");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Username).HasMaxLength(100).HasColumnName("user_name");
            entity.Property(e => e.LastLoginAt).HasColumnType("timestamp without time zone")
            .HasColumnName("last_login_at");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

        });

        modelBuilder.HasSequence("seq_categories", "inventory");
        modelBuilder.HasSequence("seq_cities", "geo");
        modelBuilder.HasSequence("seq_countries", "geo");
        modelBuilder.HasSequence("seq_customer_details_info", "sales");
        modelBuilder.HasSequence("seq_departments", "geo");
        modelBuilder.HasSequence("seq_document_types", "catalogs");
        modelBuilder.HasSequence("seq_inventory_movements", "inventory");
        modelBuilder.HasSequence("seq_method_payment", "catalogs");
        modelBuilder.HasSequence("seq_products", "inventory");
        modelBuilder.HasSequence("seq_references_type", "inventory");
        modelBuilder.HasSequence("seq_role_users_detail", "auth");
        modelBuilder.HasSequence("seq_roles", "auth");
        modelBuilder.HasSequence("seq_sale_details", "sales");
        modelBuilder.HasSequence("seq_sales", "sales");
        modelBuilder.HasSequence("seq_suppliers", "inventory");
        modelBuilder.HasSequence("seq_tax_regime", "catalogs");

    }
}
