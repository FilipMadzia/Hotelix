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
    [Migration("20240429210652_Init")]
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
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("40f946a1-4c44-4274-8afe-f5305bdfda0e"),
                            CreatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9289),
                            Name = "Bielsko-Biała",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9332)
                        },
                        new
                        {
                            Id = new Guid("3f3a7a32-a9fc-42d3-8e8f-d2d86db1d065"),
                            CreatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9347),
                            Name = "Kraków",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9349)
                        },
                        new
                        {
                            Id = new Guid("6c2991a8-eabe-4537-b18b-09c93755cfe7"),
                            CreatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9351),
                            Name = "Katowice",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 4, 29, 23, 6, 52, 268, DateTimeKind.Local).AddTicks(9353)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.AddressEntity", b =>
                {
                    b.HasOne("Hotelix.API.Data.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}
