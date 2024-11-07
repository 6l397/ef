﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using marketplace3.DataAccessLayer;

#nullable disable

namespace marketplace3.Migrations
{
    [DbContext(typeof(MarketplaceContext))]
    partial class MarketplaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            City = "City One",
                            StreetAddress = "123 Main St"
                        },
                        new
                        {
                            LocationId = 2,
                            City = "City Two",
                            StreetAddress = "456 Second St"
                        },
                        new
                        {
                            LocationId = 3,
                            City = "City Three",
                            StreetAddress = "789 Third St"
                        });
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("SellerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Sellers");

                    b.HasData(
                        new
                        {
                            SellerId = 1,
                            Description = "Description for Seller One",
                            Email = "sellerone@example.com",
                            LocationId = 1,
                            Name = "Seller One",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            SellerId = 2,
                            Description = "Description for Seller Two",
                            Email = "sellertwo@example.com",
                            LocationId = 2,
                            Name = "Seller Two",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            SellerId = 3,
                            Description = "Description for Seller Three",
                            Email = "sellerthree@example.com",
                            LocationId = 3,
                            Name = "Seller Three",
                            PhoneNumber = "555-555-5555"
                        });
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.SellerServiceCategory", b =>
                {
                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.HasKey("SellerId", "ServiceCategoryId");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("SellerServiceCategories");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.ServiceCategory", b =>
                {
                    b.Property<int>("ServiceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ServiceCategoryId");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.ServicePricing", b =>
                {
                    b.Property<int>("ServicePricingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ServicePricingId");

                    b.HasIndex("SellerId");

                    b.ToTable("ServicePricings");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.Seller", b =>
                {
                    b.HasOne("marketplace3.DataAccessLayer.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.SellerServiceCategory", b =>
                {
                    b.HasOne("marketplace3.DataAccessLayer.Entities.Seller", "Seller")
                        .WithMany("SellerServiceCategories")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("marketplace3.DataAccessLayer.Entities.ServiceCategory", "ServiceCategory")
                        .WithMany("SellerServiceCategories")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.ServicePricing", b =>
                {
                    b.HasOne("marketplace3.DataAccessLayer.Entities.Seller", "Seller")
                        .WithMany("ServicePricings")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.Seller", b =>
                {
                    b.Navigation("SellerServiceCategories");

                    b.Navigation("ServicePricings");
                });

            modelBuilder.Entity("marketplace3.DataAccessLayer.Entities.ServiceCategory", b =>
                {
                    b.Navigation("SellerServiceCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
