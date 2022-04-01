using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineMonitoring.Migrations
{
    public partial class UpdateEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "Employee",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "Employee");
        }
    }
}
