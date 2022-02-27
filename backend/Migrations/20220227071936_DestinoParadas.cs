using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class DestinoParadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_destinos_destino_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_destinos_origen_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_destinos_destino_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_destinos_origen_id",
                table: "nodos");

            migrationBuilder.DropTable(
                name: "destinos");

            migrationBuilder.CreateTable(
                name: "paradas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paradas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_paradas_nombre",
                table: "paradas",
                column: "nombre",
                unique: true,
                filter: "[nombre] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_paradas_destino_id",
                table: "boletos",
                column: "destino_id",
                principalTable: "paradas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_paradas_origen_id",
                table: "boletos",
                column: "origen_id",
                principalTable: "paradas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_paradas_destino_id",
                table: "nodos",
                column: "destino_id",
                principalTable: "paradas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_paradas_origen_id",
                table: "nodos",
                column: "origen_id",
                principalTable: "paradas",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_destino_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_origen_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_destino_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_origen_id",
                table: "nodos");

            migrationBuilder.DropTable(
                name: "paradas");

            migrationBuilder.CreateTable(
                name: "destinos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_destinos", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_destinos_nombre",
                table: "destinos",
                column: "nombre",
                unique: true,
                filter: "[nombre] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_destinos_destino_id",
                table: "boletos",
                column: "destino_id",
                principalTable: "destinos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_destinos_origen_id",
                table: "boletos",
                column: "origen_id",
                principalTable: "destinos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_destinos_destino_id",
                table: "nodos",
                column: "destino_id",
                principalTable: "destinos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_destinos_origen_id",
                table: "nodos",
                column: "origen_id",
                principalTable: "destinos",
                principalColumn: "id");
        }
    }
}
