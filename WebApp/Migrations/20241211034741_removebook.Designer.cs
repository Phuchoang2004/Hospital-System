﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.DAL;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(hospitalDB))]
    [Migration("20241211034741_removebook")]
    partial class removebook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebApp.Models.AppointmentDetails", b =>
                {
                    b.Property<int>("AppointmentDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentDetailsID"));

                    b.Property<bool>("DateStatus")
                        .HasColumnType("bit");

                    b.Property<int>("DayID")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("HourID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.Property<int>("PolyclinicID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("AppointmentDetailsID");

                    b.HasIndex("DayID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("HourID");

                    b.HasIndex("PatientID");

                    b.HasIndex("PolyclinicID");

                    b.HasIndex("RoomNumber");

                    b.ToTable("DateDetails");

                    b.HasData(
                        new
                        {
                            AppointmentDetailsID = 1,
                            DateStatus = true,
                            DayID = 1,
                            HourID = 1,
                            PolyclinicID = 1,
                            RoomNumber = 101
                        },
                        new
                        {
                            AppointmentDetailsID = 2,
                            DateStatus = true,
                            DayID = 1,
                            HourID = 2,
                            PolyclinicID = 1,
                            RoomNumber = 102
                        },
                        new
                        {
                            AppointmentDetailsID = 3,
                            DateStatus = true,
                            DayID = 2,
                            HourID = 3,
                            PolyclinicID = 2,
                            RoomNumber = 201
                        },
                        new
                        {
                            AppointmentDetailsID = 4,
                            DateStatus = true,
                            DayID = 2,
                            HourID = 4,
                            PolyclinicID = 2,
                            RoomNumber = 202
                        },
                        new
                        {
                            AppointmentDetailsID = 5,
                            DateStatus = true,
                            DayID = 3,
                            HourID = 3,
                            PolyclinicID = 3,
                            RoomNumber = 301
                        },
                        new
                        {
                            AppointmentDetailsID = 6,
                            DateStatus = true,
                            DayID = 3,
                            HourID = 4,
                            PolyclinicID = 2,
                            RoomNumber = 302
                        });
                });

            modelBuilder.Entity("WebApp.Models.Date", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentDetailsID")
                        .HasColumnType("int");

                    b.Property<bool>("DidUserArrive")
                        .HasColumnType("bit");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentDetailsID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("WebApp.Models.Day", b =>
                {
                    b.Property<int>("DayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayID"));

                    b.Property<string>("DayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DayID");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            DayID = 1,
                            DayName = "Monday"
                        },
                        new
                        {
                            DayID = 2,
                            DayName = "Tuesday"
                        },
                        new
                        {
                            DayID = 3,
                            DayName = "Wednesday"
                        },
                        new
                        {
                            DayID = 4,
                            DayName = "Thursday"
                        },
                        new
                        {
                            DayID = 5,
                            DayName = "Friday"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Hour", b =>
                {
                    b.Property<int>("HourID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HourID"));

                    b.Property<string>("DateHouri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HourID");

                    b.ToTable("Hours");

                    b.HasData(
                        new
                        {
                            HourID = 1,
                            DateHouri = "10:00 AM"
                        },
                        new
                        {
                            HourID = 2,
                            DateHouri = "11:00 AM"
                        },
                        new
                        {
                            HourID = 3,
                            DateHouri = "12:00 PM"
                        },
                        new
                        {
                            HourID = 4,
                            DateHouri = "1:00 PM"
                        },
                        new
                        {
                            HourID = 5,
                            DateHouri = "2:00 PM"
                        },
                        new
                        {
                            HourID = 6,
                            DateHouri = "3:00 PM"
                        },
                        new
                        {
                            HourID = 7,
                            DateHouri = "4:00 PM"
                        });
                });

            modelBuilder.Entity("WebApp.Models.MedicalRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("MedicalRecords");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Detail = "Has high blood pressure",
                            UserID = 1
                        },
                        new
                        {
                            ID = 2,
                            Detail = "Thang nay bi benh dep trai giai doan cuoi, dep trai ko the chua dc, noi chung la vay!",
                            UserID = 1
                        });
                });

            modelBuilder.Entity("WebApp.Models.Polyclinic", b =>
                {
                    b.Property<int>("PolyclinicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PolyclinicID"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolyclinicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PolyclinicID");

                    b.ToTable("Polyclinics");

                    b.HasData(
                        new
                        {
                            PolyclinicID = 1,
                            Image = "image1.jpg",
                            PolyclinicName = "Ear, Nose, and Throat"
                        },
                        new
                        {
                            PolyclinicID = 2,
                            Image = "image2.jpg",
                            PolyclinicName = "General Surgery"
                        },
                        new
                        {
                            PolyclinicID = 3,
                            Image = "image3.jpg",
                            PolyclinicName = "Eye"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        });
                });

            modelBuilder.Entity("WebApp.Models.Room", b =>
                {
                    b.Property<int>("RoomNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomNumber"));

                    b.Property<int>("PolyclinicID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomNumber");

                    b.HasIndex("PolyclinicID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            RoomNumber = 101,
                            PolyclinicID = 1,
                            Status = "Available"
                        },
                        new
                        {
                            RoomNumber = 102,
                            PolyclinicID = 1,
                            Status = "Available"
                        },
                        new
                        {
                            RoomNumber = 201,
                            PolyclinicID = 2,
                            Status = "Available"
                        },
                        new
                        {
                            RoomNumber = 202,
                            PolyclinicID = 2,
                            Status = "Available"
                        },
                        new
                        {
                            RoomNumber = 301,
                            PolyclinicID = 3,
                            Status = "Available"
                        },
                        new
                        {
                            RoomNumber = 302,
                            PolyclinicID = 3,
                            Status = "Available"
                        });
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nameres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Date_VM", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("DayID")
                        .HasColumnType("int");

                    b.Property<string>("Hour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("date_VMs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("WebApp.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("WebApp.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WebApp.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.AppointmentDetails", b =>
                {
                    b.HasOne("WebApp.Models.AppointmentDetails", "Parent")
                        .WithMany("DateDetails")
                        .HasForeignKey("AppointmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Day", "Day")
                        .WithMany("DateDetails")
                        .HasForeignKey("DayID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApp.Models.Hour", "Hour")
                        .WithMany("DateDetails")
                        .HasForeignKey("HourID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApp.Models.Polyclinic", "Polyclinics")
                        .WithMany("AppointmentsDetails")
                        .HasForeignKey("PolyclinicID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Doctor");

                    b.Navigation("Hour");

                    b.Navigation("Parent");

                    b.Navigation("Patient");

                    b.Navigation("Polyclinics");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("WebApp.Models.Date", b =>
                {
                    b.HasOne("WebApp.Models.AppointmentDetails", "AppointmentDetails")
                        .WithMany()
                        .HasForeignKey("AppointmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApp.Models.User", null)
                        .WithMany("Appointments")
                        .HasForeignKey("UserId");

                    b.Navigation("AppointmentDetails");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("WebApp.Models.MedicalRecord", b =>
                {
                    b.HasOne("WebApp.Models.User", "User")
                        .WithMany("MedicalRecords")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApp.Models.Room", b =>
                {
                    b.HasOne("WebApp.Models.Polyclinic", "Polyclinic")
                        .WithMany("Rooms")
                        .HasForeignKey("PolyclinicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Polyclinic");
                });

            modelBuilder.Entity("WebApp.Models.AppointmentDetails", b =>
                {
                    b.Navigation("DateDetails");
                });

            modelBuilder.Entity("WebApp.Models.Day", b =>
                {
                    b.Navigation("DateDetails");
                });

            modelBuilder.Entity("WebApp.Models.Hour", b =>
                {
                    b.Navigation("DateDetails");
                });

            modelBuilder.Entity("WebApp.Models.Polyclinic", b =>
                {
                    b.Navigation("AppointmentsDetails");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("WebApp.Models.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("MedicalRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
