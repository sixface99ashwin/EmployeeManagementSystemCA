using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemCA.Migrations
{
    public partial class RelationEstablished1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestLeaves_Employees_EmployeesEmpId",
                table: "RequestLeaves");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmployeesEmpId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeesEmpId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_RequestLeaves_EmployeesEmpId",
                table: "RequestLeaves");

            migrationBuilder.DropColumn(
                name: "EmployeesEmpId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "EmployeesEmpId",
                table: "RequestLeaves");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmpId",
                table: "WorkingHours",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLeaves_EmpId",
                table: "RequestLeaves",
                column: "EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLeaves_Employees_EmpId",
                table: "RequestLeaves",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmpId",
                table: "WorkingHours",
                column: "EmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestLeaves_Employees_EmpId",
                table: "RequestLeaves");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmpId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmpId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_RequestLeaves_EmpId",
                table: "RequestLeaves");

            migrationBuilder.AddColumn<string>(
                name: "EmployeesEmpId",
                table: "WorkingHours",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeesEmpId",
                table: "RequestLeaves",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeesEmpId",
                table: "WorkingHours",
                column: "EmployeesEmpId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestLeaves_EmployeesEmpId",
                table: "RequestLeaves",
                column: "EmployeesEmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestLeaves_Employees_EmployeesEmpId",
                table: "RequestLeaves",
                column: "EmployeesEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmployeesEmpId",
                table: "WorkingHours",
                column: "EmployeesEmpId",
                principalTable: "Employees",
                principalColumn: "EmpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
