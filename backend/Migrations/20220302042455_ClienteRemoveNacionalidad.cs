using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class ClienteRemoveNacionalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_paises_nacionalidad_id",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_clientes_nacionalidad_id",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "nacionalidad_id",
                table: "clientes");

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "distribuciones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "distribuciones");

            migrationBuilder.AddColumn<int>(
                name: "nacionalidad_id",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_clientes_nacionalidad_id",
                table: "clientes",
                column: "nacionalidad_id");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_paises_nacionalidad_id",
                table: "clientes",
                column: "nacionalidad_id",
                principalTable: "paises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
