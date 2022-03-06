using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class RemoveProvincia1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "provincias",
                keyColumn: "id",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "provincias",
                columns: new[] { "id", "nombre", "pais_id", "sigla" },
                values: new object[] { 1, "Subdivision name", 32, "3166-2 code" });
        }
    }
}
