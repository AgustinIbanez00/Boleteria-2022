using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class IgnoreCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_clientes_pasajero_id",
                table: "boletos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_boletos_pasajero_id",
                table: "boletos");

            migrationBuilder.DropColumn(
                name: "pasajero_id",
                table: "boletos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "pasajero_id",
                table: "boletos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    fecha_nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    genero = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clientes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_boletos_pasajero_id",
                table: "boletos",
                column: "pasajero_id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_clientes_pasajero_id",
                table: "boletos",
                column: "pasajero_id",
                principalTable: "clientes",
                principalColumn: "id");
        }
    }
}
