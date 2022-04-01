using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineMonitoring.Migrations
{
    public partial class AddLineNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCurrent",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Line",
                table: "Employee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCurrent",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "Employee");
        }
    }
}
