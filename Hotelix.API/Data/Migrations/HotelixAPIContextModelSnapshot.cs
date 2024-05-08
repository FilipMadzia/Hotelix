﻿// <auto-generated />
using System;
using Hotelix.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotelix.API.Data.Migrations
{
    [DbContext(typeof(HotelixAPIContext))]
    partial class HotelixAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

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

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8999),
                            HotelId = 1,
                            HouseNumber = 10,
                            PostalCode = "43-382",
                            SoftDeleted = false,
                            Street = "Tańskiego",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9000)
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9005),
                            HotelId = 2,
                            HouseNumber = 12,
                            PostalCode = "43-345",
                            SoftDeleted = false,
                            Street = "Słowackiego",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9006)
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9008),
                            HotelId = 3,
                            HouseNumber = 1,
                            PostalCode = "31-436",
                            SoftDeleted = false,
                            Street = "Wojska polskiego",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9010)
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9012),
                            HotelId = 4,
                            HouseNumber = 24,
                            PostalCode = "31-450",
                            SoftDeleted = false,
                            Street = "Powstańców",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9013)
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9015),
                            HotelId = 5,
                            HouseNumber = 34,
                            PostalCode = "40-102",
                            SoftDeleted = false,
                            Street = "Węglowa",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9016)
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9019),
                            HotelId = 6,
                            HouseNumber = 4,
                            PostalCode = "40-304",
                            SoftDeleted = false,
                            Street = "Kopalniana",
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9020)
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

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8847),
                            Name = "Bielsko-Biała",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8891)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8897),
                            Name = "Kraków",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8898)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8900),
                            Name = "Katowice",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8901)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HotelId")
                        .IsUnique();

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9046),
                            Email = "prezydent@hotelix.pl",
                            HotelId = 1,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9047)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9052),
                            HotelId = 2,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9053)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9055),
                            Email = "kierownik@hotelix.pl",
                            HotelId = 3,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9056)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9058),
                            Email = "praktykant@hotelix.pl",
                            HotelId = 4,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9059)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9061),
                            HotelId = 5,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9062)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9065),
                            Email = "senior@hotelix.pl",
                            HotelId = 6,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(9066)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoverImagePath = "Images\\Covers\\background.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8934),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Prezydent",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8935)
                        },
                        new
                        {
                            Id = 2,
                            CoverImagePath = "Images\\Covers\\background2.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8953),
                            Name = "Hotel Prezes",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8954)
                        },
                        new
                        {
                            Id = 3,
                            CoverImagePath = "Images\\Covers\\background3.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8957),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Kierownik",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8958)
                        },
                        new
                        {
                            Id = 4,
                            CoverImagePath = "Images\\Covers\\background4.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8961),
                            Name = "Hotel Praktykant",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8963)
                        },
                        new
                        {
                            Id = 5,
                            CoverImagePath = "Images\\Covers\\background5.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8965),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Stażysta",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8966)
                        },
                        new
                        {
                            Id = 6,
                            CoverImagePath = "Images\\Covers\\background6.jpg",
                            CreatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8970),
                            Name = "Hotel Senior",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 8, 17, 37, 56, 794, DateTimeKind.Local).AddTicks(8972)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.AddressEntity", b =>
                {
                    b.HasOne("Hotelix.API.Data.Entities.CityEntity", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hotelix.API.Data.Entities.HotelEntity", "Hotel")
                        .WithOne("Address")
                        .HasForeignKey("Hotelix.API.Data.Entities.AddressEntity", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.ContactEntity", b =>
                {
                    b.HasOne("Hotelix.API.Data.Entities.HotelEntity", "Hotel")
                        .WithOne("Contact")
                        .HasForeignKey("Hotelix.API.Data.Entities.ContactEntity", "HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.CityEntity", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.HotelEntity", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
