using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOTELNAPOLI.Migrations
{
    /// <inheritdoc />
    public partial class servizi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Prezzo",
                table: "Servizi",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRichiestaServizio",
                table: "Servizi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IDPrenotazione",
                table: "Servizi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Servizi_IDPrenotazione",
                table: "Servizi",
                column: "IDPrenotazione");

            migrationBuilder.AddForeignKey(
                name: "FK_Servizi_Prenotazioni_IDPrenotazione",
                table: "Servizi",
                column: "IDPrenotazione",
                principalTable: "Prenotazioni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servizi_Prenotazioni_IDPrenotazione",
                table: "Servizi");

            migrationBuilder.DropIndex(
                name: "IX_Servizi_IDPrenotazione",
                table: "Servizi");

            migrationBuilder.DropColumn(
                name: "DataRichiestaServizio",
                table: "Servizi");

            migrationBuilder.DropColumn(
                name: "IDPrenotazione",
                table: "Servizi");

            migrationBuilder.AlterColumn<decimal>(
                name: "Prezzo",
                table: "Servizi",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
