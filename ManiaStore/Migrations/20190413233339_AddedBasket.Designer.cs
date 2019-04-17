﻿// <auto-generated />
using System;
using BrandVille.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrandVille.Migrations
{
    [DbContext(typeof(BrandVilleContext))]
    [Migration("20190413233339_AddedBasket")]
    partial class AddedBasket
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrandVille.Areas.Identity.Data.BrandVilleUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ManiaStore.Models.DetailedPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bill");

                    b.Property<string>("Coins");

                    b.Property<string>("Currency");

                    b.Property<string>("Full");

                    b.Property<string>("FullString");

                    b.HasKey("Id");

                    b.ToTable("DetailedPrice");
                });

            modelBuilder.Entity("ManiaStore.Models.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Src");

                    b.HasKey("Id");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("ManiaStore.Models.Pictures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackId");

                    b.Property<int?>("FrontId");

                    b.HasKey("Id");

                    b.HasIndex("BackId");

                    b.HasIndex("FrontId");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("ManiaStore.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency");

                    b.Property<string>("CurrentPrice");

                    b.Property<bool>("IsLastPrice");

                    b.Property<string>("ProductId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Price");
                });

            modelBuilder.Entity("ManiaStore.Models.PriceRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CurrentPriceId");

                    b.Property<int?>("SellMaxId");

                    b.Property<int?>("SellMinId");

                    b.HasKey("Id");

                    b.HasIndex("CurrentPriceId");

                    b.HasIndex("SellMaxId");

                    b.HasIndex("SellMinId");

                    b.ToTable("PriceRange");
                });

            modelBuilder.Entity("ManiaStore.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("BrandVilleUserId");

                    b.Property<string>("Category");

                    b.Property<string>("FavouriteCounter");

                    b.Property<string>("ForAuction");

                    b.Property<bool>("IsMultiplePrice");

                    b.Property<string>("ManiaSize");

                    b.Property<int?>("PicturesId");

                    b.Property<int?>("PriceRangeId");

                    b.Property<string>("Rating");

                    b.Property<int>("ReservedUserId");

                    b.Property<string>("Size");

                    b.Property<string>("SizeLabel");

                    b.Property<string>("Status");

                    b.Property<string>("Type");

                    b.Property<string>("Url");

                    b.Property<bool>("WithLabel");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandVilleUserId");

                    b.HasIndex("PicturesId");

                    b.HasIndex("PriceRangeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ManiaStore.Models.Pictures", b =>
                {
                    b.HasOne("ManiaStore.Models.Picture", "Back")
                        .WithMany()
                        .HasForeignKey("BackId");

                    b.HasOne("ManiaStore.Models.Picture", "Front")
                        .WithMany()
                        .HasForeignKey("FrontId");
                });

            modelBuilder.Entity("ManiaStore.Models.Price", b =>
                {
                    b.HasOne("ManiaStore.Models.Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("ManiaStore.Models.PriceRange", b =>
                {
                    b.HasOne("ManiaStore.Models.DetailedPrice", "CurrentPrice")
                        .WithMany()
                        .HasForeignKey("CurrentPriceId");

                    b.HasOne("ManiaStore.Models.DetailedPrice", "SellMax")
                        .WithMany()
                        .HasForeignKey("SellMaxId");

                    b.HasOne("ManiaStore.Models.DetailedPrice", "SellMin")
                        .WithMany()
                        .HasForeignKey("SellMinId");
                });

            modelBuilder.Entity("ManiaStore.Models.Product", b =>
                {
                    b.HasOne("BrandVille.Areas.Identity.Data.BrandVilleUser")
                        .WithMany("BasketItems")
                        .HasForeignKey("BrandVilleUserId");

                    b.HasOne("ManiaStore.Models.Pictures", "Pictures")
                        .WithMany()
                        .HasForeignKey("PicturesId");

                    b.HasOne("ManiaStore.Models.PriceRange", "PriceRange")
                        .WithMany()
                        .HasForeignKey("PriceRangeId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BrandVille.Areas.Identity.Data.BrandVilleUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BrandVille.Areas.Identity.Data.BrandVilleUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrandVille.Areas.Identity.Data.BrandVilleUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BrandVille.Areas.Identity.Data.BrandVilleUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
