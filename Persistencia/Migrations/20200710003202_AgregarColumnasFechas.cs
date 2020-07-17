using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class AgregarColumnasFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TimeReport",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DiasDisponibles",
                table: "ProyectoEtapa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proyecto",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TotalDiasDuracion",
                table: "Proyecto",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalHorasDuracion",
                table: "Proyecto",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Etapa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Cliente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TimeReport");

            migrationBuilder.DropColumn(
                name: "DiasDisponibles",
                table: "ProyectoEtapa");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "TotalDiasDuracion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "TotalHorasDuracion",
                table: "Proyecto");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Etapa");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Cliente");
        }
    }
}
