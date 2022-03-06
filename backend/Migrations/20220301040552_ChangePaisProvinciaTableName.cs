using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class ChangePaisProvinciaTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paradas_pais_pais_id",
                table: "paradas");

            migrationBuilder.DropForeignKey(
                name: "fk_provincia_pais_pais_id",
                table: "provincia");

            migrationBuilder.DropPrimaryKey(
                name: "pk_provincia",
                table: "provincia");

            migrationBuilder.DropPrimaryKey(
                name: "pk_pais",
                table: "pais");

            migrationBuilder.RenameTable(
                name: "provincia",
                newName: "provincias");

            migrationBuilder.RenameTable(
                name: "pais",
                newName: "paises");

            migrationBuilder.RenameIndex(
                name: "ix_provincia_pais_id",
                table: "provincias",
                newName: "ix_provincias_pais_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_provincias",
                table: "provincias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_paises",
                table: "paises",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas",
                column: "pais_id",
                principalTable: "paises",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_provincias_paises_pais_id",
                table: "provincias",
                column: "pais_id",
                principalTable: "paises",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_paradas_paises_pais_id",
                table: "paradas");

            migrationBuilder.DropForeignKey(
                name: "fk_provincias_paises_pais_id",
                table: "provincias");

            migrationBuilder.DropPrimaryKey(
                name: "pk_provincias",
                table: "provincias");

            migrationBuilder.DropPrimaryKey(
                name: "pk_paises",
                table: "paises");

            migrationBuilder.RenameTable(
                name: "provincias",
                newName: "provincia");

            migrationBuilder.RenameTable(
                name: "paises",
                newName: "pais");

            migrationBuilder.RenameIndex(
                name: "ix_provincias_pais_id",
                table: "provincia",
                newName: "ix_provincia_pais_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_provincia",
                table: "provincia",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_pais",
                table: "pais",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_paradas_pais_pais_id",
                table: "paradas",
                column: "pais_id",
                principalTable: "pais",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_provincia_pais_pais_id",
                table: "provincia",
                column: "pais_id",
                principalTable: "pais",
                principalColumn: "id");
        }
    }
}
