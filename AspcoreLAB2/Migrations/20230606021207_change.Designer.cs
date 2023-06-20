﻿// <auto-generated />
using System;
using AspcoreLAB2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspcoreLAB2.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20230606021207_change")]
    partial class change
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspcoreLAB2.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.Property<int?>("ins_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.CursResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TraineeId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manger")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("ins_id")
                        .HasColumnType("int");

                    b.Property<int?>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_id");

                    b.HasIndex("dept_id");

                    b.ToTable("instructors");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("crs_id")
                        .HasColumnType("int");

                    b.Property<int?>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("crs_id");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Course", b =>
                {
                    b.HasOne("AspcoreLAB2.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("dept_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.CursResult", b =>
                {
                    b.HasOne("AspcoreLAB2.Models.Course", "Course")
                        .WithMany("CursResults")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspcoreLAB2.Models.Trainee", "Trainee")
                        .WithMany("CursResults")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Instructor", b =>
                {
                    b.HasOne("AspcoreLAB2.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("crs_id");

                    b.HasOne("AspcoreLAB2.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("dept_id");

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Trainee", b =>
                {
                    b.HasOne("AspcoreLAB2.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("AspcoreLAB2.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("crs_id");

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Course", b =>
                {
                    b.Navigation("CursResults");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("AspcoreLAB2.Models.Trainee", b =>
                {
                    b.Navigation("CursResults");
                });
#pragma warning restore 612, 618
        }
    }
}
