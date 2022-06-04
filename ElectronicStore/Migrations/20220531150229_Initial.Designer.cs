﻿// <auto-generated />
using System;
using ElectronicStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicStore.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220531150229_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicStore.Models.Producer", b =>
                {
                    b.Property<int>("producerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("producerDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("producerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("producerPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("producerID");

                    b.ToTable("producers");
                });

            modelBuilder.Entity("ElectronicStore.Models.Product", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("producerID")
                        .HasColumnType("int");

                    b.Property<int>("productCategory")
                        .HasColumnType("int");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("productPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("producyListDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("sellerID")
                        .HasColumnType("int");

                    b.HasKey("productID");

                    b.HasIndex("producerID");

                    b.HasIndex("sellerID");

                    b.ToTable("products");
                });

            modelBuilder.Entity("ElectronicStore.Models.Seller", b =>
                {
                    b.Property<int>("sellerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("sellerDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sellerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sellerPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sellerID");

                    b.ToTable("sellers");
                });

            modelBuilder.Entity("ElectronicStore.Models.Warranty", b =>
                {
                    b.Property<int>("warrantyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("warrantyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warrantyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("warrantyPictureURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("warrantyID");

                    b.ToTable("warranties");
                });

            modelBuilder.Entity("ElectronicStore.Models.WarrantytoProduct", b =>
                {
                    b.Property<int>("warrantyID")
                        .HasColumnType("int");

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.HasKey("warrantyID", "productID");

                    b.HasIndex("productID");

                    b.ToTable("warrantytoProducts");
                });

            modelBuilder.Entity("ElectronicStore.Models.Product", b =>
                {
                    b.HasOne("ElectronicStore.Models.Producer", "producers")
                        .WithMany("products")
                        .HasForeignKey("producerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicStore.Models.Seller", "sellers")
                        .WithMany("products")
                        .HasForeignKey("sellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("producers");

                    b.Navigation("sellers");
                });

            modelBuilder.Entity("ElectronicStore.Models.WarrantytoProduct", b =>
                {
                    b.HasOne("ElectronicStore.Models.Product", "product")
                        .WithMany("warrantytoProducts")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicStore.Models.Warranty", "warranty")
                        .WithMany("warrantytoProducts")
                        .HasForeignKey("warrantyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("warranty");
                });

            modelBuilder.Entity("ElectronicStore.Models.Producer", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("ElectronicStore.Models.Product", b =>
                {
                    b.Navigation("warrantytoProducts");
                });

            modelBuilder.Entity("ElectronicStore.Models.Seller", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("ElectronicStore.Models.Warranty", b =>
                {
                    b.Navigation("warrantytoProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
