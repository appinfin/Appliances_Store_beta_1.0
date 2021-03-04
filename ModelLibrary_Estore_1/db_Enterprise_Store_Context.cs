using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ModelLibrary_Estore_1
{
    public partial class db_Enterprise_Store_Context : DbContext
    {
        public db_Enterprise_Store_Context()
        {
        }

        public db_Enterprise_Store_Context(DbContextOptions<db_Enterprise_Store_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Counterparty> Counterpartys { get; set; }
        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<PersonnelsInfo> PersonnelsInfos { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsGroup> ProductsGroups { get; set; }
        public virtual DbSet<ProductsGroupsSale> ProductsGroupsSales { get; set; }
        public virtual DbSet<Realization> Realizations { get; set; }
        public virtual DbSet<RealizationPriceQty> RealizationPriceQtys { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<SupplyPriceQty> SupplyPriceQtys { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Database=db_Enterprise_Store_1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(e => e.BrandName, "UK_BrandName")
                    .IsUnique();

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Counterparty>(entity =>
            {
                entity.Property(e => e.CounterpartyName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.PersonnelName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<PersonnelsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PersonnelsInfo");

                entity.HasIndex(e => e.PersonnelsPersonnelId, "IX_PersonnelsInfo_PersonnelsPersonnelId");

                entity.HasIndex(e => new { e.PersonnelsPersonnelId, e.Passport }, "UK_Passport_PersonnelsPersonnelId")
                    .IsUnique();

                entity.HasOne(d => d.PersonnelsPersonnel)
                    .WithMany()
                    .HasForeignKey(d => d.PersonnelsPersonnelId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.BrandsBrandId, "IX_Products_BrandsBrandId");

                entity.HasIndex(e => e.ProductsGroupsProductGroupId, "IX_Products_ProductsGroupsProductGroupId");

                entity.HasIndex(e => e.UnitsIdUnit, "IX_Products_UnitsIdUnit");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.BrandsBrand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandsBrandId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.ProductsGroupsProductGroup)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductsGroupsProductGroupId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.UnitsIdUnitNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitsIdUnit)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ProductsGroup>(entity =>
            {
                entity.HasKey(e => e.ProductGroupId);

                entity.HasIndex(e => e.ProductGroupName, "UK_ProductGroupName")
                    .IsUnique();

                entity.Property(e => e.ProductGroupName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<ProductsGroupsSale>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ProductsGroupsProductGroupId, "IX_ProductsGroupsSales_ProductsGroupsProductGroupId");

                entity.HasOne(d => d.ProductsGroupsProductGroup)
                    .WithMany()
                    .HasForeignKey(d => d.ProductsGroupsProductGroupId);
            });

            modelBuilder.Entity<Realization>(entity =>
            {
                entity.HasIndex(e => e.CounterpartysCounterpartyId, "IX_Realizations_CounterpartysCounterpartyId");

                entity.HasIndex(e => e.PersonnelsPersonnelId, "IX_Realizations_PersonnelsPersonnelId");

                entity.HasIndex(e => e.StoragesStorageId, "IX_Realizations_StoragesStorageId");

                entity.Property(e => e.CounterpartysCounterpartyId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Date)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PersonnelsPersonnelId).HasDefaultValueSql("((1))");

                entity.Property(e => e.StoragesStorageId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CounterpartysCounterparty)
                    .WithMany(p => p.Realizations)
                    .HasForeignKey(d => d.CounterpartysCounterpartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PersonnelsPersonnel)
                    .WithMany(p => p.Realizations)
                    .HasForeignKey(d => d.PersonnelsPersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StoragesStorage)
                    .WithMany(p => p.Realizations)
                    .HasForeignKey(d => d.StoragesStorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RealizationPriceQty>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.RealizationId })
                    .HasName("PK_Realization_Products");

                entity.HasIndex(e => e.ProductId, "IX_RealizationPriceQtys_ProductId");

                entity.HasIndex(e => e.RealizationId, "IX_RealizationPriceQtys_RealizationId");

                entity.Property(e => e.PriceSelling)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RealizationPriceQties)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Realization)
                    .WithMany(p => p.RealizationPriceQties)
                    .HasForeignKey(d => d.RealizationId);
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.HasIndex(e => e.StorageName, "UK_StorageName")
                    .IsUnique();

                entity.Property(e => e.StorageName)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.HasIndex(e => e.CounterpartysCounterpartyId, "IX_Supplies_CounterpartysCounterpartyId");

                entity.HasIndex(e => e.StoragesStorageId, "IX_Supplies_StoragesStorageId");

                entity.Property(e => e.CounterpartysCounterpartyId).HasDefaultValueSql("((2))");

                entity.Property(e => e.Date)
                    .HasPrecision(0)
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoragesStorageId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.CounterpartysCounterparty)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.CounterpartysCounterpartyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StoragesStorage)
                    .WithMany(p => p.Supplies)
                    .HasForeignKey(d => d.StoragesStorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<SupplyPriceQty>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.SupplyId })
                    .HasName("PK_SupplyId_Products");

                entity.HasIndex(e => e.ProductId, "IX_SupplyPriceQtys_ProductId");

                entity.HasIndex(e => e.SupplyId, "IX_SupplyPriceQtys_SupplyId");

                entity.Property(e => e.PricePurchase)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SupplyPriceQties)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.SupplyPriceQties)
                    .HasForeignKey(d => d.SupplyId);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.HasIndex(e => e.UnitName, "UK_UnitName")
                    .IsUnique();

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasDefaultValueSql("(N'шт')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
