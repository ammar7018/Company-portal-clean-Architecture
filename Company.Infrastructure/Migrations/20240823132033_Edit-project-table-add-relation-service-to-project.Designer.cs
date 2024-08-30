﻿// <auto-generated />
using System;
using Company.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Company.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240823132033_Edit-project-table-add-relation-service-to-project")]
    partial class Editprojecttableaddrelationservicetoproject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Company.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("Company.Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriveLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 150000,
                            CreationDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Researching AI applications in healthcare.",
                            DriveLink = "https://drive.google.com/samplelink1",
                            EndDate = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "AI Research Project"
                        },
                        new
                        {
                            Id = 2,
                            Cost = 75000,
                            CreationDate = new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Developing an e-commerce website.",
                            DriveLink = "https://drive.google.com/samplelink2",
                            EndDate = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Web Development Project"
                        });
                });

            modelBuilder.Entity("Company.Domain.Entities.ProjectService", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ProjectServices", (string)null);
                });

            modelBuilder.Entity("Company.Domain.Entities.ProjectWorker", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("applicationUsersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ProjectId", "UserId");

                    b.HasIndex("applicationUsersId");

                    b.ToTable("ProjectWorkers", (string)null);
                });

            modelBuilder.Entity("Company.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Backend is Responsible for The back Integration of Web Application",
                            Name = "Backend"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Frontend is Responsible for The Interface of Web Application",
                            Name = "Frontend"
                        });
                });

            modelBuilder.Entity("Company.Domain.Entities.UserService", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("applicationUsersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ServiceId", "UserId");

                    b.HasIndex("applicationUsersId");

                    b.ToTable("UserServices", (string)null);
                });

            modelBuilder.Entity("Company.Domain.Entities.ProjectService", b =>
                {
                    b.HasOne("Company.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Company.Domain.Entities.ProjectWorker", b =>
                {
                    b.HasOne("Company.Domain.Entities.Project", null)
                        .WithMany("projectWorkers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Domain.Entities.ApplicationUser", null)
                        .WithMany("projectWorkers")
                        .HasForeignKey("applicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Company.Domain.Entities.UserService", b =>
                {
                    b.HasOne("Company.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Company.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("applicationUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Company.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("projectWorkers");
                });

            modelBuilder.Entity("Company.Domain.Entities.Project", b =>
                {
                    b.Navigation("projectWorkers");
                });
#pragma warning restore 612, 618
        }
    }
}
