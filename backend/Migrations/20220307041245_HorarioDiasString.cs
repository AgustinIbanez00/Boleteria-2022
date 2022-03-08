using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoleteriaOnline.Web.Migrations
{
    public partial class HorarioDiasString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "domingo",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "jueves",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "lunes",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "martes",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "miercoles",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "sabado",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "viernes",
                table: "horarios");

            migrationBuilder.AddColumn<string>(
                name: "dias",
                table: "horarios",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dias",
                table: "horarios");

            migrationBuilder.AddColumn<bool>(
                name: "domingo",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "jueves",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lunes",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "martes",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "miercoles",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "sabado",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "viernes",
                table: "horarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
