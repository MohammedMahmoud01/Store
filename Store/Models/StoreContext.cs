using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domains;
#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Store.Models
{
    //DbContext
    public partial class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbCustomer> TbCustomers { get; set; }
        public virtual DbSet<TbDeliveryMan> TbDeliveryMen { get; set; }
        public virtual DbSet<TbImage> TbImages { get; set; }
        public virtual DbSet<TbItem> TbItems { get; set; }
        public virtual DbSet<TbItemDiscount> TbItemDiscounts { get; set; }
        public virtual DbSet<TbPurchaseInvoice> TbPurchaseInvoices { get; set; }
        public virtual DbSet<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual DbSet<TbSalesInvoice> TbSalesInvoices { get; set; }
        public virtual DbSet<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
        public virtual DbSet<TbSubCategory> TbSubCategories { get; set; }
        public virtual DbSet<TbSupplier> TbSuppliers { get; set; }
        public virtual DbSet<TbSlider> TbSlider { get; set; }
        public virtual DbSet<TbMobileLogo> TbMobileLogo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity
            base.OnModelCreating(modelBuilder);
            // Identity

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("TbCategory");

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("TbCustomer");

                entity.HasIndex(e => e.CustomerId, "IX_TbCustomer")
                    .IsUnique();

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.HasKey(e => e.SliderId);

                entity.Property(e => e.SliderId).ValueGeneratedOnAdd();

                entity.Property(e => e.SliderImage)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Descreption)
                      .HasMaxLength(100);

                entity.Property(e => e.LongDescreption)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<TbMobileLogo>(entity =>
            {
                entity.HasKey(e => e.LogoId);

                entity.Property(e => e.ImageName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Description)
                      .HasMaxLength(100);

                entity.Property(e => e.LongDescription)
                      .HasMaxLength(100);
            });

            modelBuilder.Entity<TbDeliveryMan>(entity =>
            {
                entity.HasKey(e => e.DeliveryManId);

                entity.ToTable("TbDeliveryMan");

                entity.HasIndex(e => e.DeliveryManId, "IX_TbDeliveryMan")
                    .IsUnique();

                entity.Property(e => e.DeliveryManId).ValueGeneratedNever();

                entity.Property(e => e.DeliveryManName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("TbImage");

                entity.Property(e => e.ImageId).ValueGeneratedOnAdd();

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbImages)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbImage_TbItem");
            });

            modelBuilder.Entity<TbItem>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("TbItem");

                entity.Property(e => e.ItemId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreationBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Mohammed Mahmoud')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.UpdationBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Mohammed Mahmoud')");

                entity.Property(e => e.UpdationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbCategory");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.TbItems)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbItem_TbSubCategory");
            });

            modelBuilder.Entity<TbItemDiscount>(entity =>
            {
                entity.HasKey(e => e.ItemDiscountId);

                entity.ToTable("TbItemDiscount");

                entity.HasIndex(e => e.ItemDiscountId, "IX_TbItemDiscount")
                    .IsUnique();

                entity.Property(e => e.ItemDiscountId).ValueGeneratedOnAdd();

                entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate()+(60))");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Item)
                   .WithMany(p => p.TbItemDiscounts)
                   .HasForeignKey(d => d.ItemId);

            });

            modelBuilder.Entity<TbPurchaseInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);

                entity.ToTable("TbPurchaseInvoice");

                entity.HasIndex(e => e.InvoiceId, "IX_TbPurchaseInvoice")
                    .IsUnique();

                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).IsRequired();

                entity.Property(e => e.UpdationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.TbPurchaseInvoices)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoice_TbSupplier");
            });

            modelBuilder.Entity<TbPurchaseInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId);

                entity.ToTable("TbPurchaseInvoiceItem");

                entity.HasIndex(e => e.InvoiceItemId, "IX_TbPurchaseInvoiceItem")
                    .IsUnique();

                entity.Property(e => e.InvoiceItemId).ValueGeneratedNever();

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TbPurchaseInvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItem_TbPurchaseInvoice");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbPurchaseInvoiceItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbPurchaseInvoiceItem_TbItem");
            });

            modelBuilder.Entity<TbSalesInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId)
                    .HasName("PK_TbInvoice");

                entity.ToTable("TbSalesInvoice");

                entity.HasIndex(e => e.InvoiceId, "IX_TbInvoice")
                    .IsUnique();

                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.Property(e => e.InvoiceDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).IsRequired();

                entity.Property(e => e.UpdationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TbSalesInvoices)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoice_TbCustomer");

                entity.HasOne(d => d.DeliveryMan)
                    .WithMany(p => p.TbSalesInvoices)
                    .HasForeignKey(d => d.DeliveryManId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoice_TbDeliveryMan");
            });

            modelBuilder.Entity<TbSalesInvoiceItem>(entity =>
            {
                entity.HasKey(e => e.InvoiceItemId);

                entity.ToTable("TbSalesInvoiceItem");

                entity.HasIndex(e => e.InvoiceItemId, "IX_TbSalesInvoiceItem")
                    .IsUnique();

                entity.Property(e => e.InvoiceItemId).ValueGeneratedNever();

                entity.Property(e => e.SalesPrice).HasColumnType("decimal(18, 4)");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.TbSalesInvoiceItems)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItem_TbSalesInvoice");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TbSalesInvoiceItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSalesInvoiceItem_TbItem");
            });

            modelBuilder.Entity<TbSubCategory>(entity =>
            {
                entity.HasKey(e => e.SubCategoryId);

                entity.ToTable("TbSubCategory");

                entity.HasIndex(e => e.SubCategoryId, "IX_TbSubCategory")
                    .IsUnique();

                entity.Property(e => e.SubCategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.SubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TbSubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbSubCategory_TbCategory");
            });

            modelBuilder.Entity<TbSupplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("TbSupplier");

                entity.Property(e => e.SupplierId).ValueGeneratedNever();

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
