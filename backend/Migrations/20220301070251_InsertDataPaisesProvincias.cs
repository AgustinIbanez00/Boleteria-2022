using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class InsertDataPaisesProvincias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "paises");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "paises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "estado",
                table: "paises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "paises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9935), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9934) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9983), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9981) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9998), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9997) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(171), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(170) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(2), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(1) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9914), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9885) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9994), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9994) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9940), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9938) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(35), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(33) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(9), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(8) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(4), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 44,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(110), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 48,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(64), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(64) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 50,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(52), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 51,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9989), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9987) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 52,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(47), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(45) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 56,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(57), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(55) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 60,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(80), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(79) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 64,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(116), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(113) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 68,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(103), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(102) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 70,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(42), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 72,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(121), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(120) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 74,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(119), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(118) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 76,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(107), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(106) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 84,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(125), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(124) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 86,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(274), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 90,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(494), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(493) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 92,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(577), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 96,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(85), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(85) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 100,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(61), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(61) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 104,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(366), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(365) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 108,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(66), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(66) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 112,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(123), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(122) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 116,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(297), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(297) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 120,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(143), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(142) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 124,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(127), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(126) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 132,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(153), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(152) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 136,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(311), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 140,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(131), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(130) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 144,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(323), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 148,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(530), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(530) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 152,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(141), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 156,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(145), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(144) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 158,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(558), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(558) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 162,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(155), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(154) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 166,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(129), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(128) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 170,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(147), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(146) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 174,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(301), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(301) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 175,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(590), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 178,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(133), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(132) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 184,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(139), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(138) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 188,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(149), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(149) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 191,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(258), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(257) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 192,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(151), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(151) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 196,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(157), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(156) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 203,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(159), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(158) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 204,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(76), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(76) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 208,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(165), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(164) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 212,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(167), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 214,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(169), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(168) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 218,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(173), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(172) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 222,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(523), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(522) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 226,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(237), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(236) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 231,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(199), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(198) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 232,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(192), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(192) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 233,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(175), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(174) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 234,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(210), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 238,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(205), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(205) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 239,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(241), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 242,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(203), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 246,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(201), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(200) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 248,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(21), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 250,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(212), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 254,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(221), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(220) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 258,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(455), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(454) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 260,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(532), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 262,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(163), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(162) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 266,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(213), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(213) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 268,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(219), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(218) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 270,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(231), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(230) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 275,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(472), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(472) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 276,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(161), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(160) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 288,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(226), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(225) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 292,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(227), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(227) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 296,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(299), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(299) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 300,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(239), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 304,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(229), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(229) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 308,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(217), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(217) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 312,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(235), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 316,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(246), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 320,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(243), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(243) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 324,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(233), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(232) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 328,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(250), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(249) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 332,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(260), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(259) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 334,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(254), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(253) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 336,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(571), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(570) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 340,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(256), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 344,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(252), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(251) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 348,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(262), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(261) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 352,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(280), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(279) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 356,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(272), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(271) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 360,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(264), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(263) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 364,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(278), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(277) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 368,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(276), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(275) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 372,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(266), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(265) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 376,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(268), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(267) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 380,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(282), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(281) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 384,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(137), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(137) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 388,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(286), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 392,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(291), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(291) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 398,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(313), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(312) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 400,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(288), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(288) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 404,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(293), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(293) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 408,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(305), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(305) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 410,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(307), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(307) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 414,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(309), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(308) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 417,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(295), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(295) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 418,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(315), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(314) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 422,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(317), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 426,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(330), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(329) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 428,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(346), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 430,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(325), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 434,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(348), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(347) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 438,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(321), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(321) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 440,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(334), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 442,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(336), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(336) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 446,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(370), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(370) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 450,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(357), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(356) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 454,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(383), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(382) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 458,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(388), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(387) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 462,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(381), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(380) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 466,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(363), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(362) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 470,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(377), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(377) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 474,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(372), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(371) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 478,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(374), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(373) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 480,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(379), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(379) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 484,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(385), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(384) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 492,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(351), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(351) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 496,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(368), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(367) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 498,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(353), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(353) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 499,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(355), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(354) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 500,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(376), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(375) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 504,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(350), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 508,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(392), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(391) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 512,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(449), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(448) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 516,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(396), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(395) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 520,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(437), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(435) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 524,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(432), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(430) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 528,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(422), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(421) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 530,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9992), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9992) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 533,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(19), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(18) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 540,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(400), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(399) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 548,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(582), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(582) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 554,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(445), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(445) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 558,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(418), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(416) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 562,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(404), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(403) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 566,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(413), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(411) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 570,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(441), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(440) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 574,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(409), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(407) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 578,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(427), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 583,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(207), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(207) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 584,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(359), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(358) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 585,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(476), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(476) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 586,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(461), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(460) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 591,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(451), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(450) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 598,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(457), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(456) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 600,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(478), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(478) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 604,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(453), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(452) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 608,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(459), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(458) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 612,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(468), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(468) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 616,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(464), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(464) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 620,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(474), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(474) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 624,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(248), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 626,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(544), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 630,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(470), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(470) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 634,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(480), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(480) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 638,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(482), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 642,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(484), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(483) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 643,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(488), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(487) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 646,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(490), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(489) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 652,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(78), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 654,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(503), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(503) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 659,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(303), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(303) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 660,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9944), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9943) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 662,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(319), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(318) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 666,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(466), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 670,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(573), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 674,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(512), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 678,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(520), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(519) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 682,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(492), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(491) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 686,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(514), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 688,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(486), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(485) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 690,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(496), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(495) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 694,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(511), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(510) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 702,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(501), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(501) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 703,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(509), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(508) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 704,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(580), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(580) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 705,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(505), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(505) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 706,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(516), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 710,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(592), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(592) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 724,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(197), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(196) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 732,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(191), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 736,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(498), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 740,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(518), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(518) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 744,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(507), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 748,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(526), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(526) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 752,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(499), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(499) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 756,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(135), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 760,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(525), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(524) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 762,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(540), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 764,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(536), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 768,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(534), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(533) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 772,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(542), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(542) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 776,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(550), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 780,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(554), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 784,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9930), 1, new DateTime(2022, 3, 1, 4, 1, 8, 373, DateTimeKind.Local).AddTicks(9928) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 788,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(548), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 792,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(552), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 795,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(546), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 796,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(528), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(528) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 798,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(556), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 800,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(563), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(562) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 804,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(560), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 807,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(361), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(360) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 818,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(188), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(188) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 826,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(215), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(215) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 831,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(223), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(222) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 832,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(284), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 833,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(270), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(269) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 834,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(538), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 840,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(564), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 850,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(578), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(578) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 854,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(59), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(59) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 858,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(567), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(566) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 860,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(569), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(568) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 862,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(575), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 876,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(584), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 882,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(586), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "paises",
                keyColumn: "id",
                keyValue: 887,
                columns: new[] { "created_at", "estado", "updated_at" },
                values: new object[] { new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(588), 1, new DateTime(2022, 3, 1, 4, 1, 8, 374, DateTimeKind.Local).AddTicks(588) });
        }
    }
}
