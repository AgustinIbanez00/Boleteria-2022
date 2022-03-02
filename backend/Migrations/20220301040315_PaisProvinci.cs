using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class PaisProvinci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "pais",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "pais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "pais",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "provincia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pais_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_provincia", x => x.id);
                    table.ForeignKey(
                        name: "fk_provincia_pais_pais_id",
                        column: x => x.pais_id,
                        principalTable: "pais",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_provincia_pais_id",
                table: "provincia",
                column: "pais_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "provincia");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "pais");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "pais");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "pais");
        }
    }
}
