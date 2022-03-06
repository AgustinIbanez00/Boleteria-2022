using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class ChangeDataPaises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 32,
                column: "nombre",
                value: "Argentina ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 32,
                column: "nombre",
                value: "Argentina");
        }
    }
}
