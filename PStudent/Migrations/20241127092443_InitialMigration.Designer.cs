﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PStudent.Data;

#nullable disable

namespace PStudent.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241127092443_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PStudent.Data.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.HasKey("CourseId");

                    b.HasIndex("DirectionId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseName = "Основы программирования",
                            DirectionId = 1
                        },
                        new
                        {
                            CourseId = 2,
                            CourseName = "Алгоритмы и структуры данных",
                            DirectionId = 1
                        },
                        new
                        {
                            CourseId = 3,
                            CourseName = "Сетевые технологии",
                            DirectionId = 2
                        },
                        new
                        {
                            CourseId = 4,
                            CourseName = "Операционные системы",
                            DirectionId = 2
                        },
                        new
                        {
                            CourseId = 5,
                            CourseName = "Информационная безопасность",
                            DirectionId = 3
                        },
                        new
                        {
                            CourseId = 6,
                            CourseName = "Технологии баз данных",
                            DirectionId = 3
                        },
                        new
                        {
                            CourseId = 7,
                            CourseName = "Математика для программистов",
                            DirectionId = 1
                        });
                });

            modelBuilder.Entity("PStudent.Data.Direction", b =>
                {
                    b.Property<int>("DirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DirectionId"));

                    b.Property<string>("DirectionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("DirectionId");

                    b.ToTable("Directions");

                    b.HasData(
                        new
                        {
                            DirectionId = 1,
                            DirectionName = "Программирование"
                        },
                        new
                        {
                            DirectionId = 2,
                            DirectionName = "Сетевые технологии"
                        },
                        new
                        {
                            DirectionId = 3,
                            DirectionName = "Информационная безопасность"
                        });
                });

            modelBuilder.Entity("PStudent.Data.EducationType", b =>
                {
                    b.Property<int>("EducationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EducationTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("EducationTypeId");

                    b.ToTable("EducationTypes");

                    b.HasData(
                        new
                        {
                            EducationTypeId = 1,
                            TypeName = "Очное"
                        },
                        new
                        {
                            EducationTypeId = 2,
                            TypeName = "Заочное"
                        },
                        new
                        {
                            EducationTypeId = 3,
                            TypeName = "Очно-заочное"
                        });
                });

            modelBuilder.Entity("PStudent.Data.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupName = "ИБ-22вп"
                        },
                        new
                        {
                            GroupId = 2,
                            GroupName = "ИБ-23вп"
                        },
                        new
                        {
                            GroupId = 3,
                            GroupName = "ИТ-22вп"
                        },
                        new
                        {
                            GroupId = 4,
                            GroupName = "ИТ-23вп"
                        });
                });

            modelBuilder.Entity("PStudent.Data.PaymentType", b =>
                {
                    b.Property<int>("PaymentTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PaymentTypeId"));

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("PaymentTypeId");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            PaymentTypeId = 1,
                            PaymentName = "Бюджет"
                        },
                        new
                        {
                            PaymentTypeId = 2,
                            PaymentName = "Контракт"
                        });
                });

            modelBuilder.Entity("PStudent.Data.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DirectionId")
                        .HasColumnType("integer");

                    b.Property<int>("EducationTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("GraduationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PassportData")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.HasKey("StudentId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("EducationTypeId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("PStudent.Data.Course", b =>
                {
                    b.HasOne("PStudent.Data.Direction", "Direction")
                        .WithMany("Courses")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("PStudent.Data.Student", b =>
                {
                    b.HasOne("PStudent.Data.Direction", "Direction")
                        .WithMany("Students")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PStudent.Data.EducationType", "EducationType")
                        .WithMany("Students")
                        .HasForeignKey("EducationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PStudent.Data.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PStudent.Data.PaymentType", "PaymentType")
                        .WithMany("Students")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Direction");

                    b.Navigation("EducationType");

                    b.Navigation("Group");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("PStudent.Data.Direction", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("PStudent.Data.EducationType", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("PStudent.Data.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("PStudent.Data.PaymentType", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
