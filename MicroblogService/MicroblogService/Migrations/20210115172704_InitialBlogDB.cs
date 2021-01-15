using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroblogService.Migrations
{
    public partial class InitialBlogDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { 1, "It is first test note in DB", "First test note", 1 });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Description", "Title", "UserId" },
                values: new object[] { 2, "It is second test note in DB", "Second test note", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
