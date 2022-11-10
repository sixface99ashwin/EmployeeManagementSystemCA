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
    [Migration("20221107212633_Employee-fields-added")]
    partial class Employeefieldsadded
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DesignationName");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PolicyDetails")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeaveType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RequestId");

                    b.ToTable("RequestLeaves");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.WorkingHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyWorkingHour")
                        .HasColumnType("int");

                    b.Property<string>("EmpId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeWorkingHour")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("EmployeeManagementSystemCA.Models.Employee", b =>
                {
                    b.HasOne("EmployeeManagementSystemCA.Models.Designation", "Designations")
                        .WithMany()
                        .HasForeignKey("DesignationName");
                });
#pragma warning restore 612, 618
        }
    }
}
