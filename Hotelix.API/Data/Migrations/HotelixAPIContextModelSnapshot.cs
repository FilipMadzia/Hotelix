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
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8744),
                            HotelId = 1,
                            HouseNumber = 10,
                            PostalCode = "43-382",
                            SoftDeleted = false,
                            Street = "Tańskiego",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8812)
                        },
                        new
                        {
                            Id = 2,
                            CityId = 1,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8818),
                            HotelId = 2,
                            HouseNumber = 12,
                            PostalCode = "43-345",
                            SoftDeleted = false,
                            Street = "Słowackiego",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8819)
                        },
                        new
                        {
                            Id = 3,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8822),
                            HotelId = 3,
                            HouseNumber = 1,
                            PostalCode = "31-436",
                            SoftDeleted = false,
                            Street = "Wojska polskiego",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8823)
                        },
                        new
                        {
                            Id = 4,
                            CityId = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8825),
                            HotelId = 4,
                            HouseNumber = 24,
                            PostalCode = "31-450",
                            SoftDeleted = false,
                            Street = "Powstańców",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8826)
                        },
                        new
                        {
                            Id = 5,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8828),
                            HotelId = 5,
                            HouseNumber = 34,
                            PostalCode = "40-102",
                            SoftDeleted = false,
                            Street = "Węglowa",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8829)
                        },
                        new
                        {
                            Id = 6,
                            CityId = 3,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8832),
                            HotelId = 6,
                            HouseNumber = 4,
                            PostalCode = "40-304",
                            SoftDeleted = false,
                            Street = "Kopalniana",
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8834)
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
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8593),
                            Name = "Bielsko-Biała",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8637)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8648),
                            Name = "Kraków",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8649)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8651),
                            Name = "Katowice",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8652)
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
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8867),
                            Email = "prezydent@hotelix.pl",
                            HotelId = 1,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8869)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8873),
                            HotelId = 2,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8874)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8876),
                            Email = "kierownik@hotelix.pl",
                            HotelId = 3,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8877)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8879),
                            Email = "praktykant@hotelix.pl",
                            HotelId = 4,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8880)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8882),
                            HotelId = 5,
                            PhoneNumber = "123 456 789",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8883)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8886),
                            Email = "senior@hotelix.pl",
                            HotelId = 6,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8887)
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

                    b.Property<bool>("HasCafeteria")
                        .HasColumnType("bit");

                    b.Property<bool>("HasInternet")
                        .HasColumnType("bit");

                    b.Property<bool>("HasParking")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTelevision")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerNight")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

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
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8686),
                            Description = "Hotel Prezydent to kwintesencja luksusu i wygody, położony w samym sercu miasta. Ten prestiżowy hotel oferuje swoim gościom nie tylko wyjątkowe wnętrza, ale również najnowocześniejsze udogodnienia, takie jak telewizja satelitarna i szybki internet bezprzewodowy. Każdy pokój w hotelu został zaprojektowany z myślą o komforcie i stylu, zapewniając idealne warunki do odpoczynku i pracy. Goście mogą delektować się wyśmienitymi daniami w eleganckiej jadalni, gdzie serwowane są potrawy przygotowane przez renomowanych szefów kuchni. Hotelowa restauracja słynie z doskonałej kuchni i obsługi na najwyższym poziomie. Hotel Prezydent jest doskonałym miejscem dla tych, którzy pragną połączyć relaks z rozrywką. Tuż obok hotelu znajduje się słynne kasyno, które przyciąga miłośników gier i emocji. To idealne miejsce na spędzenie wieczoru, próbując szczęścia w grach karcianych czy ruletce. Zapraszamy do Hotelu Prezydenta, gdzie luksus spotyka się z komfortem, a każdy pobyt staje się niezapomnianym doświadczeniem.",
                            HasCafeteria = true,
                            HasInternet = true,
                            HasParking = false,
                            HasTelevision = true,
                            Name = "Hotel Prezydent",
                            PricePerNight = 69.99m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8688)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8696),
                            HasCafeteria = false,
                            HasInternet = false,
                            HasParking = false,
                            HasTelevision = true,
                            Name = "Hotel Prezes",
                            PricePerNight = 52.00m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8698)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8700),
                            Description = "Hotel Kierownik to oaza spokoju i luksusu, położona na przedmieściach, z dala od miejskiego zgiełku. Ten elegancki hotel zaprasza gości do przestronnych i komfortowo urządzonych pokoi, gdzie każdy detal został dopracowany z największą starannością. Centralnym punktem hotelu jest luksusowa jadalnia, która zachwyca nie tylko wykwintnym menu, ale również wyrafinowanym wystrojem. To tutaj, wśród delikatnych tkanin i lśniącego srebra, goście mogą cieszyć się wyjątkowymi daniami kuchni międzynarodowej i lokalnej, przygotowywanymi przez doświadczonych szefów kuchni. Hotel Kierownik szczyci się również przestronnym parkingiem, który zapewnia wygodę i bezpieczeństwo dla wszystkich odwiedzających. Dzięki temu goście mogą bez problemu podróżować własnym samochodem i cieszyć się łatwym dostępem do hotelu. Położony wśród zielonych terenów przedmieścia, hotel stanowi idealne miejsce dla tych, którzy szukają ciszy i relaksu, jednocześnie pragnąc zachować łatwy dostęp do atrakcji miejskich. Hotel Kierownik to wyjątkowe miejsce, które zapewnia niezapomniane wrażenia i najwyższy standard obsługi.",
                            HasCafeteria = true,
                            HasInternet = false,
                            HasParking = true,
                            HasTelevision = false,
                            Name = "Hotel Kierownik",
                            PricePerNight = 40.00m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8701)
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8704),
                            HasCafeteria = false,
                            HasInternet = false,
                            HasParking = false,
                            HasTelevision = false,
                            Name = "Hotel Praktykant",
                            PricePerNight = 1.99m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8705)
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8707),
                            HasCafeteria = false,
                            HasInternet = true,
                            HasParking = false,
                            HasTelevision = false,
                            Name = "Hotel Stażysta",
                            PricePerNight = 0.99m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8708)
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8711),
                            Description = "Hotel Senior to synonim wygody i spokoju, idealnie dostosowany do potrzeb osób starszych. Położony w cichej i bezpiecznej okolicy, hotel zapewnia swoim gościom komfortowy i dostojny wypoczynek. Wnętrza hotelu są przestronne i łatwo dostępne, co gwarantuje wygodę użytkowania przez osoby w każdym wieku. W jadalni hotelowej goście mogą cieszyć się bogatym wyborem potraw, które są nie tylko smaczne, ale również dostosowane do różnorodnych diet i potrzeb żywieniowych. Każdy posiłek jest przygotowywany z myślą o zdrowiu i zadowoleniu gości, co czyni jadalnię sercem hotelu. Hotel Senior oferuje również rozrywkę dzięki telewizji satelitarnej z mnóstwem kanałów, które umożliwiają dostęp do ulubionych programów, filmów i seriali. To idealne rozwiązanie dla tych, którzy cenią sobie relaks przy dobrej telewizji. Z myślą o pełnym komforcie, hotel zapewnia szereg udogodnień, takich jak obsługa pokoju, pomoc w organizacji czasu wolnego oraz transport do pobliskich atrakcji. Hotel Senior to miejsce, gdzie tradycja gościnności łączy się z nowoczesnymi rozwiązaniami, tworząc idealne warunki dla seniorów pragnących spędzić czas w przyjaznej i eleganckiej atmosferze.",
                            HasCafeteria = true,
                            HasInternet = false,
                            HasParking = false,
                            HasTelevision = true,
                            Name = "Hotel Senior",
                            PricePerNight = 15.99m,
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8713)
                        });
                });

            modelBuilder.Entity("Hotelix.API.Data.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SoftDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8913),
                            Password = "fikunia123",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8915),
                            UserName = "FilipMadzia"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8918),
                            Password = "kochamBobry",
                            SoftDeleted = false,
                            UpdatedAt = new DateTime(2024, 5, 19, 14, 1, 28, 18, DateTimeKind.Local).AddTicks(8919),
                            UserName = "WojtekWróbel"
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
