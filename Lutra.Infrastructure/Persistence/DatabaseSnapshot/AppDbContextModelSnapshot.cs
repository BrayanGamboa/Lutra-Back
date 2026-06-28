using System;
using System.Collections.Generic;
using Lutra.Infrastructure.Persistence.DatabaseSnapshot.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence.DatabaseSnapshot;

public partial class AppDbContextModelSnapshot : DbContext
{
    public AppDbContextModelSnapshot(DbContextOptions<AppDbContextModelSnapshot> options)
        : base(options)
    {
    }

    public virtual DbSet<category> categories { get; set; }

    public virtual DbSet<city> cities { get; set; }

    public virtual DbSet<city1> cities1 { get; set; }

    public virtual DbSet<country> countries { get; set; }

    public virtual DbSet<country1> countries1 { get; set; }

    public virtual DbSet<customer_details_info> customer_details_infos { get; set; }

    public virtual DbSet<department> departments { get; set; }

    public virtual DbSet<department1> departments1 { get; set; }

    public virtual DbSet<document_type> document_types { get; set; }

    public virtual DbSet<inventory_movement> inventory_movements { get; set; }

    public virtual DbSet<method_payment> method_payments { get; set; }

    public virtual DbSet<product> products { get; set; }

    public virtual DbSet<references_type> references_types { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<role_users_detail> role_users_details { get; set; }

    public virtual DbSet<sale> sales { get; set; }

    public virtual DbSet<sale_detail> sale_details { get; set; }

    public virtual DbSet<supplier> suppliers { get; set; }

    public virtual DbSet<tax_regime> tax_regimes { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<category>(entity =>
        {
            entity.HasKey(e => e.category_id).HasName("pk_categories");

            entity.ToTable("categories", "inventory");

            entity.Property(e => e.category_id).HasDefaultValueSql("nextval('inventory.seq_categories'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<city>(entity =>
        {
            entity.HasKey(e => e.city_id).HasName("pk_cities");

            entity.ToTable("cities", "catalogs");

            entity.Property(e => e.city_id).HasDefaultValueSql("nextval('geo.seq_cities'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.department).WithMany(p => p.cities)
                .HasForeignKey(d => d.department_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cities_departments_department_id");
        });

        modelBuilder.Entity<city1>(entity =>
        {
            entity.HasKey(e => e.city_id).HasName("pk_cities");

            entity.ToTable("cities", "geo");

            entity.Property(e => e.city_id).HasDefaultValueSql("nextval('geo.seq_cities'::regclass)");
            entity.Property(e => e.name).HasMaxLength(100);

            entity.HasOne(d => d.department).WithMany(p => p.city1s)
                .HasForeignKey(d => d.department_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cities_departments_department_id");
        });

        modelBuilder.Entity<country>(entity =>
        {
            entity.HasKey(e => e.country_id).HasName("pk_countries");

            entity.ToTable("countries", "geo");

            entity.Property(e => e.country_id).HasDefaultValueSql("nextval('geo.seq_countries'::regclass)");
            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<country1>(entity =>
        {
            entity.HasKey(e => e.country_id).HasName("pk_countries");

            entity.ToTable("countries", "catalogs");

            entity.Property(e => e.country_id).HasDefaultValueSql("nextval('geo.seq_countries'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<customer_details_info>(entity =>
        {
            entity.HasKey(e => e.customer_detail_id).HasName("pk_customer_details_info");

            entity.ToTable("customer_details_info", "sales");

            entity.Property(e => e.customer_detail_id).HasDefaultValueSql("nextval('sales.seq_customer_details_info'::regclass)");
            entity.Property(e => e.billing_address).HasMaxLength(255);
            entity.Property(e => e.business_name).HasMaxLength(150);
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.customer_document).HasMaxLength(30);
            entity.Property(e => e.customer_name).HasMaxLength(150);
            entity.Property(e => e.document_number).HasMaxLength(30);
            entity.Property(e => e.phone).HasMaxLength(30);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.city).WithMany(p => p.customer_details_infos)
                .HasForeignKey(d => d.city_id)
                .HasConstraintName("fk_customer_details_info_cities_city_id");

            entity.HasOne(d => d.document_type).WithMany(p => p.customer_details_infos)
                .HasForeignKey(d => d.document_type_id)
                .HasConstraintName("fk_customer_details_info_document_types_document_type_id");

            entity.HasOne(d => d.tax_regime).WithMany(p => p.customer_details_infos)
                .HasForeignKey(d => d.tax_regime_id)
                .HasConstraintName("fk_customer_details_info_tax_regime_tax_regime_id");

            entity.HasOne(d => d.user).WithMany(p => p.customer_details_infos)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_details_info_users_user_id");
        });

        modelBuilder.Entity<department>(entity =>
        {
            entity.HasKey(e => e.department_id).HasName("pk_departments");

            entity.ToTable("departments", "geo");

            entity.Property(e => e.department_id).HasDefaultValueSql("nextval('geo.seq_departments'::regclass)");
            entity.Property(e => e.name).HasMaxLength(100);

            entity.HasOne(d => d.country).WithMany(p => p.departments)
                .HasForeignKey(d => d.country_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_departments_countries_country_id");
        });

        modelBuilder.Entity<department1>(entity =>
        {
            entity.HasKey(e => e.department_id).HasName("pk_departments");

            entity.ToTable("departments", "catalogs");

            entity.Property(e => e.department_id).HasDefaultValueSql("nextval('geo.seq_departments'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.country).WithMany(p => p.department1s)
                .HasForeignKey(d => d.country_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_departments_countries_country_id");
        });

        modelBuilder.Entity<document_type>(entity =>
        {
            entity.HasKey(e => e.document_type_id).HasName("pk_document_types");

            entity.ToTable("document_types", "catalogs");

            entity.Property(e => e.document_type_id).HasDefaultValueSql("nextval('catalogs.seq_document_types'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<inventory_movement>(entity =>
        {
            entity.HasKey(e => e.movement_id).HasName("pk_inventory_movements");

            entity.ToTable("inventory_movements", "inventory");

            entity.Property(e => e.movement_id).HasDefaultValueSql("nextval('inventory.seq_inventory_movements'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.movement_type).HasMaxLength(20);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.product).WithMany(p => p.inventory_movements)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_movements_products_product_id");

            entity.HasOne(d => d.reference).WithMany(p => p.inventory_movements)
                .HasForeignKey(d => d.reference_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_inventory_movements_references_type_reference_id");
        });

        modelBuilder.Entity<method_payment>(entity =>
        {
            entity.HasKey(e => e.payment_method_id).HasName("pk_method_payment");

            entity.ToTable("method_payment", "catalogs");

            entity.Property(e => e.payment_method_id).HasDefaultValueSql("nextval('catalogs.seq_method_payment'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<product>(entity =>
        {
            entity.HasKey(e => e.product_id).HasName("pk_products");

            entity.ToTable("products", "inventory");

            entity.HasIndex(e => e.sku, "products_sku_key").IsUnique();

            entity.Property(e => e.product_id).HasDefaultValueSql("nextval('inventory.seq_products'::regclass)");
            entity.Property(e => e.cost).HasPrecision(12, 2);
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.name).HasMaxLength(150);
            entity.Property(e => e.price).HasPrecision(12, 2);
            entity.Property(e => e.sku).HasMaxLength(50);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.category).WithMany(p => p.products)
                .HasForeignKey(d => d.category_id)
                .HasConstraintName("fk_products_categories_category_id");

            entity.HasOne(d => d.supplier).WithMany(p => p.products)
                .HasForeignKey(d => d.supplier_id)
                .HasConstraintName("fk_products_suppliers_supplier_id");
        });

        modelBuilder.Entity<references_type>(entity =>
        {
            entity.HasKey(e => e.reference_type_id).HasName("pk_references_type");

            entity.ToTable("references_type", "inventory");

            entity.Property(e => e.reference_type_id).HasDefaultValueSql("nextval('inventory.seq_references_type'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.role_id).HasName("pk_roles");

            entity.ToTable("roles", "auth");

            entity.Property(e => e.role_id).HasDefaultValueSql("nextval('auth.seq_roles'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<role_users_detail>(entity =>
        {
            entity.HasKey(e => e.role_user_detail_id).HasName("pk_role_users_detail");

            entity.ToTable("role_users_detail", "auth");

            entity.Property(e => e.role_user_detail_id).HasDefaultValueSql("nextval('auth.seq_role_users_detail'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.role).WithMany(p => p.role_users_details)
                .HasForeignKey(d => d.role_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_users_detail_roles_role_id");

            entity.HasOne(d => d.user).WithMany(p => p.role_users_details)
                .HasForeignKey(d => d.user_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role_users_detail_users_user_id");
        });

        modelBuilder.Entity<sale>(entity =>
        {
            entity.HasKey(e => e.sale_id).HasName("pk_sales");

            entity.ToTable("sales", "sales");

            entity.Property(e => e.sale_id).ValueGeneratedNever();
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.sale_date)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.status)
                .HasMaxLength(20)
                .HasDefaultValueSql("'PENDING'::character varying");
            entity.Property(e => e.total_amount).HasPrecision(14, 2);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.customer).WithMany(p => p.sales)
                .HasForeignKey(d => d.customer_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_users_customer_id");

            entity.HasOne(d => d.payment_method).WithMany(p => p.sales)
                .HasForeignKey(d => d.payment_method_id)
                .HasConstraintName("fk_sales_method_payment_payment_method_id");
        });

        modelBuilder.Entity<sale_detail>(entity =>
        {
            entity.HasKey(e => e.sale_detail_id).HasName("pk_sale_details");

            entity.ToTable("sale_details", "sales");

            entity.Property(e => e.sale_detail_id).HasDefaultValueSql("nextval('sales.seq_sale_details'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.subtotal).HasPrecision(14, 2);
            entity.Property(e => e.unit_price).HasPrecision(12, 2);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.product).WithMany(p => p.sale_details)
                .HasForeignKey(d => d.product_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_details_products_product_id");

            entity.HasOne(d => d.sale).WithMany(p => p.sale_details)
                .HasForeignKey(d => d.sale_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_details_sales_sale_id");
        });

        modelBuilder.Entity<supplier>(entity =>
        {
            entity.HasKey(e => e.supplier_id).HasName("pk_suppliers");

            entity.ToTable("suppliers", "inventory");

            entity.Property(e => e.supplier_id).HasDefaultValueSql("nextval('inventory.seq_suppliers'::regclass)");
            entity.Property(e => e.address).HasMaxLength(255);
            entity.Property(e => e.contact_name).HasMaxLength(100);
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.email).HasMaxLength(150);
            entity.Property(e => e.name).HasMaxLength(150);
            entity.Property(e => e.phone).HasMaxLength(30);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<tax_regime>(entity =>
        {
            entity.HasKey(e => e.tax_regime_id).HasName("pk_tax_regime");

            entity.ToTable("tax_regime", "catalogs");

            entity.Property(e => e.tax_regime_id).HasDefaultValueSql("nextval('catalogs.seq_tax_regime'::regclass)");
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.description).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.update_at).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.user_id).HasName("pk_users");

            entity.ToTable("users", "auth");

            entity.HasIndex(e => e.email, "users_email_key").IsUnique();

            entity.Property(e => e.user_id).ValueGeneratedNever();
            entity.Property(e => e.create_at)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.email).HasMaxLength(150);
            entity.Property(e => e.is_active).HasDefaultValue(true);
            entity.Property(e => e.lastname).HasMaxLength(100);
            entity.Property(e => e.name).HasMaxLength(100);
            entity.Property(e => e.user_name).HasMaxLength(100);
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
