using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LineMonitoring.Migrations
{
    public partial class Create_Graph_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Line1 = table.Column<string>(type: "TEXT", nullable: true),
                    Line2 = table.Column<string>(type: "TEXT", nullable: true),
                    Data1 = table.Column<string>(type: "TEXT", nullable: true),
                    Data2 = table.Column<string>(type: "TEXT", nullable: true),
                    Axis = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graph", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Graph",
                columns: new[] { "Id", "Axis", "Data1", "Data2", "Line1", "Line2", "Title" },
                values: new object[] { 1, "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec", "1,2,3,4,5,6,7,8,9,10,11,12", "0.1,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,0.10,0.11,0.12", "Label for Data 1", "Label for Data 2", "Graph Title" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Graph");
        }
    }
}
