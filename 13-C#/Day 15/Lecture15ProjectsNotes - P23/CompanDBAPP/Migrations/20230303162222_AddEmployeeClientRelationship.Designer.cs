﻿// <auto-generated />
using System;
using CompanDBAPP.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanDBAPP.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20230303162222_AddEmployeeClientRelationship")]
    partial class AddEmployeeClientRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BranchClient", b =>
                {
                    b.Property<int>("BranchesID")
                        .HasColumnType("int");

                    b.Property<int>("ClientsCID")
                        .HasColumnType("int");

                    b.HasKey("BranchesID", "ClientsCID");

                    b.HasIndex("ClientsCID");

                    b.ToTable("BranchClient");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Branch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Client", b =>
                {
                    b.Property<int>("CID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CID"));

                    b.Property<decimal>("Deposite")
                        .HasColumnType("money")
                        .HasColumnName("OrderDeposite");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MName")
                        .HasMaxLength(2)
                        .HasColumnType("nchar(2)")
                        .IsFixedLength();

                    b.HasKey("CID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Employee", b =>
                {
                    b.Property<int>("EId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EId"));

                    b.Property<int?>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("MName")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("Money");

                    b.HasKey("EId");

                    b.HasIndex("BranchID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.EmployeeClient", b =>
                {
                    b.Property<int>("EmployeeEID")
                        .HasColumnType("int");

                    b.Property<int>("ClientCID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Visit")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeEID", "ClientCID");

                    b.HasIndex("ClientCID");

                    b.ToTable("EmployeeClient");
                });

            modelBuilder.Entity("BranchClient", b =>
                {
                    b.HasOne("CompanDBAPP.Entites.Branch", null)
                        .WithMany()
                        .HasForeignKey("BranchesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanDBAPP.Entites.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientsCID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Employee", b =>
                {
                    b.HasOne("CompanDBAPP.Entites.Branch", "Branch")
                        .WithMany("Employees")
                        .HasForeignKey("BranchID");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.EmployeeClient", b =>
                {
                    b.HasOne("CompanDBAPP.Entites.Client", "Client")
                        .WithMany("EmployeeClients")
                        .HasForeignKey("ClientCID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CompanDBAPP.Entites.Employee", "Employee")
                        .WithMany("EmployeeClients")
                        .HasForeignKey("EmployeeEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Branch", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Client", b =>
                {
                    b.Navigation("EmployeeClients");
                });

            modelBuilder.Entity("CompanDBAPP.Entites.Employee", b =>
                {
                    b.Navigation("EmployeeClients");
                });
#pragma warning restore 612, 618
        }
    }
}