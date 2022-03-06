using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class PaisId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pais_id",
                table: "paradas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "paradas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "pais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    sigla = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pais", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_paradas_pais_id",
                table: "paradas",
                column: "pais_id");

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_pais_pais_id",
                table: "paradas",
                column: "pais_id",
                principalTable: "pais",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paradas_pais_pais_id",
                table: "paradas");

            migrationBuilder.DropTable(
                name: "pais");

            migrationBuilder.DropIndex(
                name: "ix_paradas_pais_id",
                table: "paradas");

            migrationBuilder.DropColumn(
                name: "pais_id",
                table: "paradas");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "paradas");
        }
    }
}
