using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class NodoViajeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_clientes_pasajero_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_destino_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_origen_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_usuarios_vendedor_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_viajes_recorrido_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_destino_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_origen_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_viajes_viaje_id",
                table: "nodos");

            migrationBuilder.DropIndex(
                name: "ix_boletos_pasajero_id",
                table: "boletos");

            migrationBuilder.RenameColumn(
                name: "vendedor_id",
                table: "boletos",
                newName: "pasajero_id1");

            migrationBuilder.RenameIndex(
                name: "ix_boletos_vendedor_id",
                table: "boletos",
                newName: "ix_boletos_pasajero_id1");

            migrationBuilder.AlterColumn<int>(
                name: "viaje_id",
                table: "nodos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "origen_id",
                table: "nodos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "destino_id",
                table: "nodos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "recorrido_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "precio",
                table: "boletos",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pasajero_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pago_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "origen_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estado",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "destino_id",
                table: "boletos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "boletos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "boletos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_clientes_pasajero_id1",
                table: "boletos",
                column: "pasajero_id1",
                principalTable: "clientes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos",
                column: "pago_id",
                principalTable: "pagos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_paradas_destino_id",
                table: "boletos",
                column: "destino_id",
                principalTable: "paradas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_paradas_origen_id",
                table: "boletos",
                column: "origen_id",
                principalTable: "paradas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_viajes_recorrido_id",
                table: "boletos",
                column: "recorrido_id",
                principalTable: "viajes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_paradas_destino_id",
                table: "nodos",
                column: "destino_id",
                principalTable: "paradas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_paradas_origen_id",
                table: "nodos",
                column: "origen_id",
                principalTable: "paradas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_viajes_viaje_id",
                table: "nodos",
                column: "viaje_id",
                principalTable: "viajes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_boletos_clientes_pasajero_id1",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_destino_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_paradas_origen_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_boletos_viajes_recorrido_id",
                table: "boletos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_destino_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_paradas_origen_id",
                table: "nodos");

            migrationBuilder.DropForeignKey(
                name: "fk_nodos_viajes_viaje_id",
                table: "nodos");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "boletos");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "boletos");

            migrationBuilder.RenameColumn(
                name: "pasajero_id1",
                table: "boletos",
                newName: "vendedor_id");

            migrationBuilder.RenameIndex(
                name: "ix_boletos_pasajero_id1",
                table: "boletos",
                newName: "ix_boletos_vendedor_id");

            migrationBuilder.AlterColumn<int>(
                name: "viaje_id",
                table: "nodos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "origen_id",
                table: "nodos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "destino_id",
                table: "nodos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "recorrido_id",
                table: "boletos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "precio",
                table: "boletos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<long>(
                name: "pasajero_id",
                table: "boletos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "pago_id",
                table: "boletos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "origen_id",
                table: "boletos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "estado",
                table: "boletos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "destino_id",
                table: "boletos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_pagos_pago_id",
                table: "boletos",
                column: "pago_id",
                principalTable: "pagos",
                principalColumn: "id");

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
                name: "fk_boletos_usuarios_vendedor_id",
                table: "boletos",
                column: "vendedor_id",
                principalTable: "usuarios",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_boletos_viajes_recorrido_id",
                table: "boletos",
                column: "recorrido_id",
                principalTable: "viajes",
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

            migrationBuilder.AddForeignKey(
                name: "fk_nodos_viajes_viaje_id",
                table: "nodos",
                column: "viaje_id",
                principalTable: "viajes",
                principalColumn: "id");
        }
    }
}
