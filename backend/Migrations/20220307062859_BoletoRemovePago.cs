using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class BoletoRemovePago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos");

            migrationBuilder.DropIndex(
                name: "ix_boletos_pago_id",
                table: "boletos");

            migrationBuilder.DropColumn(
                name: "fecha_emision",
                table: "boletos");

            migrationBuilder.DropColumn(
                name: "hora_salida_adicional",
                table: "boletos");

            migrationBuilder.DropColumn(
                name: "pago_id",
                table: "boletos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_emision",
                table: "boletos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "hora_salida_adicional",
                table: "boletos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pago_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_boletos_pago_id",
                table: "boletos",
                column: "pago_id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos",
                column: "pago_id",
                principalTable: "pagos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
