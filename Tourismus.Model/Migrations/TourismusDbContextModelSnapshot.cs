﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tourismus.Model.Models;

namespace Tourismus.Model.Migrations
{
    [DbContext(typeof(TourismusDbContext))]
    partial class TourismusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Tourismus.Model.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAirport")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhotosPaths")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Star")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("MealsId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("HotelId");

                    b.HasIndex("MealsId");

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Tourismus.Model.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Token")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tourismus.Model.Models.UserCredential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCredentials");
                });

            modelBuilder.Entity("Tourismus.Model.Models.City", b =>
                {
                    b.HasOne("Tourismus.Model.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Cities_Countries")
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Hotel", b =>
                {
                    b.HasOne("Tourismus.Model.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Offer", b =>
                {
                    b.HasOne("Tourismus.Model.Models.City", "City")
                        .WithMany("Offers")
                        .HasForeignKey("CityId")
                        .HasConstraintName("FK_Offers_Cities")
                        .IsRequired();

                    b.HasOne("Tourismus.Model.Models.Hotel", "Hotel")
                        .WithMany("Offers")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK_Offers_Hotels")
                        .IsRequired();

                    b.HasOne("Tourismus.Model.Models.Meal", "Meals")
                        .WithMany("Offers")
                        .HasForeignKey("MealsId")
                        .HasConstraintName("FK_Offers_Meals");

                    b.Navigation("City");

                    b.Navigation("Hotel");

                    b.Navigation("Meals");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Reservation", b =>
                {
                    b.HasOne("Tourismus.Model.Models.Offer", "Offer")
                        .WithMany("Reservations")
                        .HasForeignKey("OfferId")
                        .HasConstraintName("FK_Reservations_Offers")
                        .IsRequired();

                    b.HasOne("Tourismus.Model.Models.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Reservations_Users")
                        .IsRequired();

                    b.Navigation("Offer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tourismus.Model.Models.UserCredential", b =>
                {
                    b.HasOne("Tourismus.Model.Models.User", "User")
                        .WithMany("UserCredentials")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserCredentials_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tourismus.Model.Models.City", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Hotel", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Meal", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("Tourismus.Model.Models.Offer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Tourismus.Model.Models.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("UserCredentials");
                });
#pragma warning restore 612, 618
        }
    }
}
