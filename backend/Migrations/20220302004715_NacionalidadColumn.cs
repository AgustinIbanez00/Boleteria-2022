using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class NacionalidadColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas");

            migrationBuilder.DropIndex(
                name: "ix_paradas_nombre",
                table: "paradas");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "paradas");

            migrationBuilder.DropColumn(
                name: "nacionalidad",
                table: "clientes");

            migrationBuilder.AlterColumn<int>(
                name: "pais_id",
                table: "paradas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "provincia_id",
                table: "paradas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "genero",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nacionalidad_id",
                table: "clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_paradas_nombre_pais_id_provincia_id",
                table: "paradas",
                columns: new[] { "nombre", "pais_id", "provincia_id" },
                unique: true,
                filter: "[nombre] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_paradas_provincia_id",
                table: "paradas",
                column: "provincia_id");

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

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas",
                column: "pais_id",
                principalTable: "paises",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_provincias_provincia_id",
                table: "paradas",
                column: "provincia_id",
                principalTable: "provincias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_paises_nacionalidad_id",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas");

            migrationBuilder.DropForeignKey(
                name: "fk_paradas_provincias_provincia_id",
                table: "paradas");

            migrationBuilder.DropIndex(
                name: "ix_paradas_nombre_pais_id_provincia_id",
                table: "paradas");

            migrationBuilder.DropIndex(
                name: "ix_paradas_provincia_id",
                table: "paradas");

            migrationBuilder.DropIndex(
                name: "ix_clientes_nacionalidad_id",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "provincia_id",
                table: "paradas");

            migrationBuilder.DropColumn(
                name: "nacionalidad_id",
                table: "clientes");

            migrationBuilder.AlterColumn<int>(
                name: "pais_id",
                table: "paradas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "paradas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "genero",
                table: "clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "nacionalidad",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_paradas_nombre",
                table: "paradas",
                column: "nombre",
                unique: true,
                filter: "[nombre] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas",
                column: "pais_id",
                principalTable: "paises",
                principalColumn: "id");
        }
    }
}
