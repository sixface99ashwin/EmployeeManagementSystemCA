﻿// <auto-generated />
using System;
using EmployeeManagementSystemCA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagementSystemCA.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20221104151652_Relation-Established1")]
    partial class RelationEstablished1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.Designation", b =>
                {
                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("DesignationName");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("DesignationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EmpName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.HasIndex("DesignationName");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.PaymentRule", b =>
                {
                    b.Property<int>("RuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Policy")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RuleId");

                    b.ToTable("PaymentRules");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.RequestLeave", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50);

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50);

                    b.HasKey("RequestId");

                    b.HasIndex("EmpId");

                    b.ToTable("RequestLeaves");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.WorkingHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyWorkingHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EmpId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("EmployeeWorkingHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.Employee", b =>
                {
                    b.HasOne("EmployeeManagementSystemCA.Models.Designation", "Designations")
                        .WithMany()
                        .HasForeignKey("DesignationName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.RequestLeave", b =>
                {
                    b.HasOne("EmployeeManagementSystemCA.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmpId");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.WorkingHour", b =>
                {
                    b.HasOne("EmployeeManagementSystemCA.Models.Employee", "Employees")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
