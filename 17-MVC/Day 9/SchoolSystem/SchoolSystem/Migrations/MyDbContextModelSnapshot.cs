﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SchoolSystem.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolSystem.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Topic")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("SchoolSystem.Models.Track", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Tracks", (string)null);
                });

            modelBuilder.Entity("SchoolSystem.Models.Trainee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("MobileNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrackID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TrackID");

                    b.ToTable("Trainees", (string)null);
                });

            modelBuilder.Entity("SchoolSystem.Models.TraineeCourse", b =>
                {
                    b.Property<int>("TraineeID")
                        .HasColumnType("int");

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("TraineeID", "CourseID");

                    b.HasIndex("CourseID");

                    b.ToTable("TraineeCourses", (string)null);
                });

            modelBuilder.Entity("SchoolSystem.Models.Trainee", b =>
                {
                    b.HasOne("SchoolSystem.Models.Track", "Track")
                        .WithMany("Trainees")
                        .HasForeignKey("TrackID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");
                });

            modelBuilder.Entity("SchoolSystem.Models.TraineeCourse", b =>
                {
                    b.HasOne("SchoolSystem.Models.Course", "Course")
                        .WithMany("TraineeCourses")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolSystem.Models.Trainee", "Trainee")
                        .WithMany("TraineeCourses")
                        .HasForeignKey("TraineeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("SchoolSystem.Models.Course", b =>
                {
                    b.Navigation("TraineeCourses");
                });

            modelBuilder.Entity("SchoolSystem.Models.Track", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("SchoolSystem.Models.Trainee", b =>
                {
                    b.Navigation("TraineeCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
