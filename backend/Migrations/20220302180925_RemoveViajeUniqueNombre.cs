using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class RemoveViajeUniqueNombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_viajes_nombre",
                table: "viajes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_viajes_nombre",
                table: "viajes",
                column: "nombre",
                unique: true,
                filter: "[nombre] IS NOT NULL");
        }
    }
}
