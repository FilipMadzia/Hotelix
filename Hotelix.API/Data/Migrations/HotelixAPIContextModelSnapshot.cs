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
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3254),
                            HotelId = 1,
                            HouseNumber = 10,
                            PostalCode = "43-382",
                            SoftDeleted = false,
                            Street = "Tańskiego",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3256)
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3261),
                            HotelId = 2,
                            HouseNumber = 12,
                            PostalCode = "43-345",
                            SoftDeleted = false,
                            Street = "Słowackiego",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3262)
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3265),
                            HotelId = 3,
                            HouseNumber = 1,
                            PostalCode = "31-436",
                            SoftDeleted = false,
                            Street = "Wojska polskiego",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3266)
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3269),
                            HotelId = 4,
                            HouseNumber = 24,
                            PostalCode = "31-450",
                            SoftDeleted = false,
                            Street = "Powstańców",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3270)
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3272),
                            HotelId = 5,
                            HouseNumber = 34,
                            PostalCode = "40-102",
                            SoftDeleted = false,
                            Street = "Węglowa",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3273)
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3277),
                            HotelId = 6,
                            HouseNumber = 4,
                            PostalCode = "40-304",
                            SoftDeleted = false,
                            Street = "Kopalniana",
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3278)
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
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3111),
                            Name = "Bielsko-Biała",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3156)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3162),
                            Name = "Kraków",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3164)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3166),
                            Name = "Katowice",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3167)
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
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3303),
                            Email = "prezydent@hotelix.pl",
                            HotelId = 1,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3305)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3310),
                            HotelId = 2,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3312)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3314),
                            Email = "kierownik@hotelix.pl",
                            HotelId = 3,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3315)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3317),
                            Email = "praktykant@hotelix.pl",
                            HotelId = 4,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3318)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3320),
                            HotelId = 5,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3321)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3325),
                            Email = "senior@hotelix.pl",
                            HotelId = 6,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3326)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.HotelEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3200),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Prezydent",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3202)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3207),
                            Name = "Hotel Prezes",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3208)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3210),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Kierownik",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3212)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3214),
                            Name = "Hotel Praktykant",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3215)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3217),
                            Description = "Lorem Ipsum",
                            Name = "Hotel Stażysta",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3218)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3222),
                            Name = "Hotel Senior",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 7, 22, 24, 32, 343, DateTimeKind.Local).AddTicks(3224)
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
