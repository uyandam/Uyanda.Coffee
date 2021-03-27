﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Uyanda.Coffee.Persistence;

namespace Uyanda.Coffee.Persistence.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    partial class LocalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Data")
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeverageTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("BeverageTypeId");

                    b.ToTable("Beverage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeverageTypeId = 1,
                            IsActive = true,
                            Name = "Coffee"
                        },
                        new
                        {
                            Id = 2,
                            BeverageTypeId = 1,
                            IsActive = true,
                            Name = "Five Roses"
                        },
                        new
                        {
                            Id = 3,
                            BeverageTypeId = 2,
                            IsActive = true,
                            Name = "Milkshake"
                        });
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageSizeCostEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeverageId")
                        .HasColumnType("int");

                    b.Property<int>("BeverageSizeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BeverageSizeId");

                    b.HasIndex("BeverageId", "BeverageSizeId")
                        .IsUnique();

                    b.ToTable("BeverageCost");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BeverageId = 1,
                            BeverageSizeId = 1,
                            Cost = 15m
                        },
                        new
                        {
                            Id = 2,
                            BeverageId = 2,
                            BeverageSizeId = 1,
                            Cost = 25m
                        },
                        new
                        {
                            Id = 3,
                            BeverageId = 3,
                            BeverageSizeId = 1,
                            Cost = 30m
                        },
                        new
                        {
                            Id = 4,
                            BeverageId = 1,
                            BeverageSizeId = 2,
                            Cost = 10m
                        },
                        new
                        {
                            Id = 5,
                            BeverageId = 2,
                            BeverageSizeId = 2,
                            Cost = 15m
                        },
                        new
                        {
                            Id = 6,
                            BeverageId = 3,
                            BeverageSizeId = 2,
                            Cost = 20m
                        },
                        new
                        {
                            Id = 7,
                            BeverageId = 1,
                            BeverageSizeId = 3,
                            Cost = 20m
                        },
                        new
                        {
                            Id = 8,
                            BeverageId = 2,
                            BeverageSizeId = 3,
                            Cost = 30m
                        },
                        new
                        {
                            Id = 9,
                            BeverageId = 3,
                            BeverageSizeId = 3,
                            Cost = 40m
                        });
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageSizeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BeverageSizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Large"
                        });
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BeverageTypeEntity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Hot"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cold"
                        });
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeverageSizeCostId")
                        .HasColumnType("int");

                    b.Property<decimal>("CurrencyCostPerItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("InvoiceEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeverageSizeCostId");

                    b.HasIndex("InvoiceEntityId");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PhoneNumber = "0",
                            Points = 0m
                        });
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.InvoiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrencyFinalIncoicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DiscountedPoints")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FinalInvoicePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsRedeemingPoints")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.LineItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BeverageSizeCostId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPerItem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeverageSizeCostId");

                    b.HasIndex("InvoiceEntityId");

                    b.ToTable("LineItem");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.PayEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Pay");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.BeverageTypeEntity", "BeverageType")
                        .WithMany()
                        .HasForeignKey("BeverageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.BeverageSizeCostEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.BeverageEntity", "Beverage")
                        .WithMany()
                        .HasForeignKey("BeverageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uyanda.Coffee.Persistence.Entities.BeverageSizeEntity", "BeverageSize")
                        .WithMany()
                        .HasForeignKey("BeverageSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.CurrencyEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.BeverageSizeCostEntity", "BeverageSizeCost")
                        .WithMany()
                        .HasForeignKey("BeverageSizeCostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uyanda.Coffee.Persistence.Entities.InvoiceEntity", null)
                        .WithMany("Currencies")
                        .HasForeignKey("InvoiceEntityId");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.InvoiceEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.CustomerEntity", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.LineItemEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.BeverageSizeCostEntity", "BeverageSizeCost")
                        .WithMany()
                        .HasForeignKey("BeverageSizeCostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Uyanda.Coffee.Persistence.Entities.InvoiceEntity", null)
                        .WithMany("LineItems")
                        .HasForeignKey("InvoiceEntityId");
                });

            modelBuilder.Entity("Uyanda.Coffee.Persistence.Entities.PayEntity", b =>
                {
                    b.HasOne("Uyanda.Coffee.Persistence.Entities.InvoiceEntity", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
