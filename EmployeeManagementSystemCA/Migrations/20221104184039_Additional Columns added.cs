using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemCA.Migrations
{
    public partial class AdditionalColumnsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentMonthYear",
                table: "WorkingHours",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PolicyDetails",
                table: "PaymentRules",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMonthYear",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "PolicyDetails",
                table: "PaymentRules");
        }
    }
}
