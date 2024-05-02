﻿// <auto-generated />
using System;
using Hotelix.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotelix.API.Data.Migrations
{
    [DbContext(typeof(HotelixAPIContext))]
    [Migration("20240502163845_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hotelix.API.Data.Entities.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1933),
                            HouseNumber = 10,
                            PostalCode = "43-382",
                            SoftDeleted = false,
                            Street = "Tańskiego",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1935)
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1938),
                            HouseNumber = 12,
                            PostalCode = "43-345",
                            SoftDeleted = false,
                            Street = "Słowackiego",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1939)
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1942),
                            HouseNumber = 1,
                            PostalCode = "31-436",
                            SoftDeleted = false,
                            Street = "Wojska polskiego",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1943)
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1945),
                            HouseNumber = 24,
                            PostalCode = "31-450",
                            SoftDeleted = false,
                            Street = "Powstańców",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1946)
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1948),
                            HouseNumber = 34,
                            PostalCode = "40-102",
                            SoftDeleted = false,
                            Street = "Węglowa",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1950)
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1953),
                            HouseNumber = 4,
                            PostalCode = "40-304",
                            SoftDeleted = false,
                            Street = "Kopalniana",
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1955)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1847),
                            Name = "Bielsko-Biała",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1890)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1895),
                            Name = "Kraków",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1897)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1899),
                            Name = "Katowice",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 2, 18, 38, 45, 280, DateTimeKind.Local).AddTicks(1900)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.AddressEntity", b =>
                {
                    b.HasOne("Hotelix.API.Data.Entities.CityEntity", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.CityEntity", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
