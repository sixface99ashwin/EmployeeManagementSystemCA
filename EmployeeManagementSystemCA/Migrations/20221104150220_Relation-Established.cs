using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemCA.Migrations
{
    public partial class RelationEstablished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationName = table.Column<string>(maxLength: 50, nullable: false),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationName);
                });

            migrationBuilder.CreateTable(
                name: "PaymentRules",
                columns: table => new
                {
                    RuleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentRules", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<string>(maxLength: 50, nullable: false),
                    EmpName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    DesignationName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesignationName",
                        column: x => x.DesignationName,
                        principalTable: "Designations",
                        principalColumn: "DesignationName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestLeaves",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveType = table.Column<string>(maxLength: 50, nullable: false),
                    FromDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    ToDate = table.Column<DateTime>(maxLength: 50, nullable: false),
                    EmpId = table.Column<string>(maxLength: 50, nullable: true),
                    EmployeesEmpId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLeaves", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_RequestLeaves_Employees_EmployeesEmpId",
                        column: x => x.EmployeesEmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeesEmpId = table.Column<string>(nullable: true),
                    CompanyWorkingHour = table.Column<string>(maxLength: 50, nullable: false),
                    EmployeeWorkingHour = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingHours_Employees_EmployeesEmpId",
                        column: x => x.EmployeesEmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationName",
                table: "Employees",
                column: "DesignationName");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLeaves_EmployeesEmpId",
                table: "RequestLeaves",
                column: "EmployeesEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeesEmpId",
                table: "WorkingHours",
                column: "EmployeesEmpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentRules");

            migrationBuilder.DropTable(
                name: "RequestLeaves");

            migrationBuilder.DropTable(
                name: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Designations");
        }
    }
}
