using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementSystemCA.Migrations
{
    public partial class monthfieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "WorkingHours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "WorkingHours");
        }
    }
}
