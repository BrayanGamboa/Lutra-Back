using Lutra.Domain.Auth;
using Lutra.Domain.Catalog;
using Lutra.Domain.Inventory;
using Lutra.Domain.Sales;
using Microsoft.EntityFrameworkCore;

namespace Lutra.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Auth
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleUsersDetail> UserRoles => Set<RoleUsersDetail>();

    // Catalog
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<DocumentType> DocumentTypes => Set<DocumentType>();
    public DbSet<MethodPayment> MethodPayments => Set<MethodPayment>();
    public DbSet<TaxRegime> TaxRegimes => Set<TaxRegime>();

    // Inventory
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<ReferencesType> ReferencesTypes => Set<ReferencesType>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<InventoryMovement> InventoryMovements => Set<InventoryMovement>();

    // Sales
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleDetail> SaleDetails => Set<SaleDetail>();
    public DbSet<CustomerDetailsInfo> CustomerDetailsInfos => Set<CustomerDetailsInfo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Auth

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_roles");

            entity.ToTable("roles", "auth");

            entity.Property(e => e.RoleId).HasDefaultValueSql("nextval('auth.seq_roles'::regclass)").HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp with time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<RoleUsersDetail>(entity =>
        {
            entity.HasKey(e => e.RoleUserDetailId).HasName("pk_role_users_detail");

            entity.ToTable("role_users_detail", "auth");

            entity.Property(e => e.RoleUserDetailId).HasDefaultValueSql("nextval('auth.seq_role_users_detail'::regclass)")
                .HasColumnName("role_user_detail_id");
            entity.Property(e => e.CreatedAt).HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

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
                .HasColumnType("timestamp with time zone")
                .HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.Property(e => e.Email).HasMaxLength(150).HasColumnName("email");
            entity.Property(e => e.IsActive).HasDefaultValue(true).HasColumnName("is_active");
            entity.Property(e => e.LastName).HasMaxLength(100).HasColumnName("lastname");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Username).HasMaxLength(100).HasColumnName("user_name");
            entity.Property(e => e.LastLoginAt).HasColumnType("timestamp with time zone").HasColumnName("last_login_at");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
        });
        #endregion Auth

        #region Catalog
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("pk_countries");
            entity.ToTable("countries", "catalogs");
            entity.Property(e => e.CountryId).HasDefaultValueSql("nextval('geo.seq_countries'::regclass)").HasColumnName("country_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("pk_departments");
            entity.ToTable("departments", "catalogs");
            entity.Property(e => e.DepartmentId).HasDefaultValueSql("nextval('geo.seq_departments'::regclass)").HasColumnName("department_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.HasOne(d => d.Country).WithMany().HasForeignKey(d => d.CountryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_departments_countries_country_id");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("pk_cities");
            entity.ToTable("cities", "catalogs");
            entity.Property(e => e.CityId).HasDefaultValueSql("nextval('geo.seq_cities'::regclass)").HasColumnName("city_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.HasOne(c => c.Department).WithMany().HasForeignKey(c => c.DepartmentId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_cities_departments_department_id");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.DocumentTypeId).HasName("pk_document_types");
            entity.ToTable("document_types", "catalogs");
            entity.Property(e => e.DocumentTypeId).HasDefaultValueSql("nextval('catalogs.seq_document_types'::regclass)").HasColumnName("document_type_id");
            entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("name");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<MethodPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("pk_method_payment");
            entity.ToTable("method_payment", "catalogs");
            entity.Property(e => e.PaymentMethodId).HasDefaultValueSql("nextval('catalogs.seq_method_payment'::regclass)").HasColumnName("payment_method_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<TaxRegime>(entity =>
        {
            entity.HasKey(e => e.TaxRegimeId).HasName("pk_tax_regime");
            entity.ToTable("tax_regime", "catalogs");
            entity.Property(e => e.TaxRegimeId).HasDefaultValueSql("nextval('catalogs.seq_tax_regime'::regclass)").HasColumnName("tax_regime_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });
        #endregion Catalog

        #region Inventory

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("pk_categories");
            entity.ToTable("categories", "inventory");
            entity.Property(e => e.CategoryId).HasDefaultValueSql("nextval('inventory.seq_categories'::regclass)").HasColumnName("category_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("pk_suppliers");
            entity.ToTable("suppliers", "inventory");
            entity.Property(e => e.SupplierId).HasDefaultValueSql("nextval('inventory.seq_suppliers'::regclass)").HasColumnName("supplier_id");
            entity.Property(e => e.Name).HasMaxLength(150).HasColumnName("name");
            entity.Property(e => e.ContactName).HasMaxLength(100).HasColumnName("contact_name");
            entity.Property(e => e.Email).HasMaxLength(150).HasColumnName("email");
            entity.Property(e => e.Phone).HasMaxLength(30).HasColumnName("phone");
            entity.Property(e => e.Address).HasMaxLength(255).HasColumnName("address");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<ReferencesType>(entity =>
        {
            entity.HasKey(e => e.ReferenceTypeId).HasName("pk_references_type");
            entity.ToTable("references_type", "inventory");
            entity.Property(e => e.ReferenceTypeId).HasDefaultValueSql("nextval('inventory.seq_references_type'::regclass)").HasColumnName("reference_type_id");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.Description).HasMaxLength(255).HasColumnName("description");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("pk_products");
            entity.ToTable("products", "inventory");
            entity.HasIndex(e => e.Sku, "products_sku_key").IsUnique();
            entity.Property(e => e.ProductId).HasDefaultValueSql("nextval('inventory.seq_products'::regclass)").HasColumnName("product_id");
            entity.Property(e => e.Name).HasMaxLength(150).HasColumnName("name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Sku).HasMaxLength(50).HasColumnName("sku");
            entity.Property(e => e.Price).HasPrecision(12, 2).HasColumnName("price");
            entity.Property(e => e.Cost).HasPrecision(12, 2).HasColumnName("cost");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.IsActive).HasDefaultValue(true).HasColumnName("is_active");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).HasConstraintName("fk_products_categories_category_id");
            entity.HasOne(p => p.Supplier).WithMany().HasForeignKey(p => p.SupplierId).HasConstraintName("fk_products_suppliers_supplier_id");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.HasKey(e => e.MovementId).HasName("pk_inventory_movements");
            entity.ToTable("inventory_movements", "inventory");
            entity.Property(e => e.MovementId).HasDefaultValueSql("nextval('inventory.seq_inventory_movements'::regclass)").HasColumnName("movement_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.MovementType).HasMaxLength(20).HasColumnName("movement_type");
            entity.Property(e => e.ReferenceId).HasColumnName("reference_id");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
            entity.HasOne(m => m.Product).WithMany().HasForeignKey(m => m.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_inventory_movements_products_product_id");
            entity.HasOne(m => m.Reference).WithMany().HasForeignKey(m => m.ReferenceId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_inventory_movements_references_type_reference_id");
        });
        #endregion Inventory

        #region Sales

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("pk_sales");
            entity.ToTable("sales", "sales");
            entity.Property(e => e.SaleId).ValueGeneratedNever().HasColumnName("sale_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.TotalAmount).HasPrecision(14, 2).HasColumnName("total_amount");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.SaleDate).HasDefaultValueSql("now()").HasColumnType("timestamp with time zone").HasColumnName("sale_date");
            entity.Property(e => e.Status).HasMaxLength(20).HasDefaultValueSql("'PENDING'::character varying").HasColumnName("status");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<SaleDetail>(entity =>
        {
            entity.HasKey(e => e.SaleDetailId).HasName("pk_sale_details");
            entity.ToTable("sale_details", "sales");
            entity.Property(e => e.SaleDetailId).HasDefaultValueSql("nextval('sales.seq_sale_details'::regclass)").HasColumnName("sale_detail_id");
            entity.Property(e => e.SaleId).HasColumnName("sale_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasPrecision(12, 2).HasColumnName("unit_price");
            entity.Property(e => e.Subtotal).HasPrecision(14, 2).HasColumnName("subtotal");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });

        modelBuilder.Entity<CustomerDetailsInfo>(entity =>
        {
            entity.HasKey(e => e.CustomerDetailId).HasName("pk_customer_details_info");
            entity.ToTable("customer_details_info", "sales");
            entity.Property(e => e.CustomerDetailId).HasDefaultValueSql("nextval('sales.seq_customer_details_info'::regclass)").HasColumnName("customer_detail_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");
            entity.Property(e => e.DocumentNumber).HasMaxLength(30).HasColumnName("document_number");
            entity.Property(e => e.BusinessName).HasMaxLength(150).HasColumnName("business_name");
            entity.Property(e => e.BillingAddress).HasMaxLength(255).HasColumnName("billing_address");
            entity.Property(e => e.Phone).HasMaxLength(30).HasColumnName("phone");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.TaxRegimeId).HasColumnName("tax_regime_id");
            entity.Property(e => e.CustomerName).HasMaxLength(150).HasColumnName("customer_name");
            entity.Property(e => e.CustomerDocument).HasMaxLength(30).HasColumnName("customer_document");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").HasColumnType("timestamp with time zone").HasColumnName("create_at");
            entity.Property(e => e.UpdatedAt).HasColumnType("timestamp with time zone").HasColumnName("update_at");
        });
        #endregion Sales

        #region Sequences

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
        #endregion Sequences
    }
}
