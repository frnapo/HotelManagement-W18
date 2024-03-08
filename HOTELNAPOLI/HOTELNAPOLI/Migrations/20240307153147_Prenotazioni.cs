using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOTELNAPOLI.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInizioSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFineSoggiorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Anno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acconto = table.Column<double>(type: "float", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IDClienteId = table.Column<int>(type: "int", nullable: false),
                    IDCameraID = table.Column<int>(type: "int", nullable: false),
                    IDPensioneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Camere_IDCameraID",
                        column: x => x.IDCameraID,
                        principalTable: "Camere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Clienti_IDClienteId",
                        column: x => x.IDClienteId,
                        principalTable: "Clienti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Pensioni_IDPensioneID",
                        column: x => x.IDPensioneID,
                        principalTable: "Pensioni",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDCameraID",
                table: "Prenotazioni",
                column: "IDCameraID");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDClienteId",
                table: "Prenotazioni",
                column: "IDClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_IDPensioneID",
                table: "Prenotazioni",
                column: "IDPensioneID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prenotazioni");
        }
    }
}
