﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Migrations
{
    [DbContext(typeof(UniversityRegistrarContext))]
    partial class UniversityRegistrarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("UniversityRegistrar.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CourseNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.CourseDepartment", b =>
                {
                    b.Property<int>("CourseDepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("CourseDepartmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("CourseDepartments");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.CourseStudent", b =>
                {
                    b.Property<int>("CourseStudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseStudentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudents");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfEnroll")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.CourseDepartment", b =>
                {
                    b.HasOne("UniversityRegistrar.Models.Course", "Course")
                        .WithMany("CourseDepartments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityRegistrar.Models.Department", "Department")
                        .WithMany("CourseDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.CourseStudent", b =>
                {
                    b.HasOne("UniversityRegistrar.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniversityRegistrar.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Student", b =>
                {
                    b.HasOne("UniversityRegistrar.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Course", b =>
                {
                    b.Navigation("CourseDepartments");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Department", b =>
                {
                    b.Navigation("CourseDepartments");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("UniversityRegistrar.Models.Student", b =>
                {
                    b.Navigation("CourseStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
