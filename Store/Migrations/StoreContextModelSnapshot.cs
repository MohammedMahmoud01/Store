﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store.Models;

namespace Store.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domains.TbCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("TbCategory");
                });

            modelBuilder.Entity("Domains.TbCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.HasIndex(new[] { "CustomerId" }, "IX_TbCustomer")
                        .IsUnique();

                    b.ToTable("TbCustomer");
                });

            modelBuilder.Entity("Domains.TbDeliveryMan", b =>
                {
                    b.Property<int>("DeliveryManId")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryManName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DeliveryManId");

                    b.HasIndex(new[] { "DeliveryManId" }, "IX_TbDeliveryMan")
                        .IsUnique();

                    b.ToTable("TbDeliveryMan");
                });

            modelBuilder.Entity("Domains.TbImage", b =>
                {
                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("TbImage");
                });

            modelBuilder.Entity("Domains.TbItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreationBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("('Mohammed Mahmoud')");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("UpdationBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("('Mohammed Mahmoud')");

                    b.Property<DateTime>("UpdationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("TbItem");
                });

            modelBuilder.Entity("Domains.TbItemDiscount", b =>
                {
                    b.Property<int>("ItemDiscountId")
                        .HasColumnType("int");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<decimal>("DiscountPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate()+(60))");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ItemDiscountId");

                    b.HasIndex("ItemId");

                    b.HasIndex(new[] { "ItemDiscountId" }, "IX_TbItemDiscount")
                        .IsUnique();

                    b.ToTable("TbItemDiscount");
                });

            modelBuilder.Entity("Domains.TbMobileLogo", b =>
                {
                    b.Property<int>("LogoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LogoId");

                    b.ToTable("TbMobileLogo");
                });

            modelBuilder.Entity("Domains.TbPurchaseInvoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("InvoiceId");

                    b.HasIndex("SupplierId");

                    b.HasIndex(new[] { "InvoiceId" }, "IX_TbPurchaseInvoice")
                        .IsUnique();

                    b.ToTable("TbPurchaseInvoice");
                });

            modelBuilder.Entity("Domains.TbPurchaseInvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Quantitiy")
                        .HasColumnType("int");

                    b.HasKey("InvoiceItemId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex(new[] { "InvoiceItemId" }, "IX_TbPurchaseInvoiceItem")
                        .IsUnique();

                    b.ToTable("TbPurchaseInvoiceItem");
                });

            modelBuilder.Entity("Domains.TbSalesInvoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryManId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("InvoiceId")
                        .HasName("PK_TbInvoice");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeliveryManId");

                    b.HasIndex(new[] { "InvoiceId" }, "IX_TbInvoice")
                        .IsUnique();

                    b.ToTable("TbSalesInvoice");
                });

            modelBuilder.Entity("Domains.TbSalesInvoiceItem", b =>
                {
                    b.Property<int>("InvoiceItemId")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantitiy")
                        .HasColumnType("int");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("InvoiceItemId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.HasIndex(new[] { "InvoiceItemId" }, "IX_TbSalesInvoiceItem")
                        .IsUnique();

                    b.ToTable("TbSalesInvoiceItem");
                });

            modelBuilder.Entity("Domains.TbSlider", b =>
                {
                    b.Property<int>("SliderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descreption")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LongDescreption")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SliderImage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SliderId");

                    b.ToTable("TbSlider");
                });

            modelBuilder.Entity("Domains.TbSubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex(new[] { "SubCategoryId" }, "IX_TbSubCategory")
                        .IsUnique();

                    b.ToTable("TbSubCategory");
                });

            modelBuilder.Entity("Domains.TbSupplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplierId");

                    b.ToTable("TbSupplier");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Store.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domains.TbImage", b =>
                {
                    b.HasOne("Domains.TbItem", "Item")
                        .WithMany("TbImages")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TbImage_TbItem")
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domains.TbItem", b =>
                {
                    b.HasOne("Domains.TbCategory", "Category")
                        .WithMany("TbItems")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_TbItem_TbCategory")
                        .IsRequired();

                    b.HasOne("Domains.TbSubCategory", "SubCategory")
                        .WithMany("TbItems")
                        .HasForeignKey("SubCategoryId")
                        .HasConstraintName("FK_TbItem_TbSubCategory")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Domains.TbItemDiscount", b =>
                {
                    b.HasOne("Domains.TbItem", "Item")
                        .WithMany("TbItemDiscounts")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domains.TbPurchaseInvoice", b =>
                {
                    b.HasOne("Domains.TbSupplier", "Supplier")
                        .WithMany("TbPurchaseInvoices")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK_TbPurchaseInvoice_TbSupplier")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Domains.TbPurchaseInvoiceItem", b =>
                {
                    b.HasOne("Domains.TbPurchaseInvoice", "Invoice")
                        .WithMany("TbPurchaseInvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_TbPurchaseInvoiceItem_TbPurchaseInvoice")
                        .IsRequired();

                    b.HasOne("Domains.TbItem", "Item")
                        .WithMany("TbPurchaseInvoiceItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TbPurchaseInvoiceItem_TbItem")
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domains.TbSalesInvoice", b =>
                {
                    b.HasOne("Domains.TbCustomer", "Customer")
                        .WithMany("TbSalesInvoices")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_TbSalesInvoice_TbCustomer")
                        .IsRequired();

                    b.HasOne("Domains.TbDeliveryMan", "DeliveryMan")
                        .WithMany("TbSalesInvoices")
                        .HasForeignKey("DeliveryManId")
                        .HasConstraintName("FK_TbSalesInvoice_TbDeliveryMan")
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("DeliveryMan");
                });

            modelBuilder.Entity("Domains.TbSalesInvoiceItem", b =>
                {
                    b.HasOne("Domains.TbSalesInvoice", "Invoice")
                        .WithMany("TbSalesInvoiceItems")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_TbSalesInvoiceItem_TbSalesInvoice")
                        .IsRequired();

                    b.HasOne("Domains.TbItem", "Item")
                        .WithMany("TbSalesInvoiceItems")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK_TbSalesInvoiceItem_TbItem")
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domains.TbSubCategory", b =>
                {
                    b.HasOne("Domains.TbCategory", "Category")
                        .WithMany("TbSubCategories")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_TbSubCategory_TbCategory")
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Store.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domains.TbCategory", b =>
                {
                    b.Navigation("TbItems");

                    b.Navigation("TbSubCategories");
                });

            modelBuilder.Entity("Domains.TbCustomer", b =>
                {
                    b.Navigation("TbSalesInvoices");
                });

            modelBuilder.Entity("Domains.TbDeliveryMan", b =>
                {
                    b.Navigation("TbSalesInvoices");
                });

            modelBuilder.Entity("Domains.TbItem", b =>
                {
                    b.Navigation("TbImages");

                    b.Navigation("TbItemDiscounts");

                    b.Navigation("TbPurchaseInvoiceItems");

                    b.Navigation("TbSalesInvoiceItems");
                });

            modelBuilder.Entity("Domains.TbPurchaseInvoice", b =>
                {
                    b.Navigation("TbPurchaseInvoiceItems");
                });

            modelBuilder.Entity("Domains.TbSalesInvoice", b =>
                {
                    b.Navigation("TbSalesInvoiceItems");
                });

            modelBuilder.Entity("Domains.TbSubCategory", b =>
                {
                    b.Navigation("TbItems");
                });

            modelBuilder.Entity("Domains.TbSupplier", b =>
                {
                    b.Navigation("TbPurchaseInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
