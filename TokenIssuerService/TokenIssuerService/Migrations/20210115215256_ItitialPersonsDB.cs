using Microsoft.EntityFrameworkCore.Migrations;

namespace TokenIssuerService.Migrations
{
    public partial class ItitialPersonsDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 1, "admin@gmail.com", "12345", "admin" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { 2, "qwerty@gmail.com", "55555", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
