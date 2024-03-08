using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOTELNAPOLI.Migrations
{
    /// <inheritdoc />
    public partial class Prenotazioni2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_IDCameraID",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Clienti_IDClienteId",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Pensioni_IDPensioneID",
                table: "Prenotazioni");

            migrationBuilder.RenameColumn(
                name: "IDPensioneID",
                table: "Prenotazioni",
                newName: "IDPensione");

            migrationBuilder.RenameColumn(
                name: "IDClienteId",
                table: "Prenotazioni",
                newName: "IDCliente");

            migrationBuilder.RenameColumn(
                name: "IDCameraID",
                table: "Prenotazioni",
                newName: "IDCamera");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDPensioneID",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDPensione");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDClienteId",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDCameraID",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDCamera");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni",
                column: "IDCamera",
                principalTable: "Camere",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni",
                column: "IDCliente",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Pensioni_IDPensione",
                table: "Prenotazioni",
                column: "IDPensione",
                principalTable: "Pensioni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Camere_IDCamera",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Clienti_IDCliente",
                table: "Prenotazioni");

            migrationBuilder.DropForeignKey(
                name: "FK_Prenotazioni_Pensioni_IDPensione",
                table: "Prenotazioni");

            migrationBuilder.RenameColumn(
                name: "IDPensione",
                table: "Prenotazioni",
                newName: "IDPensioneID");

            migrationBuilder.RenameColumn(
                name: "IDCliente",
                table: "Prenotazioni",
                newName: "IDClienteId");

            migrationBuilder.RenameColumn(
                name: "IDCamera",
                table: "Prenotazioni",
                newName: "IDCameraID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDPensione",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDPensioneID");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDCliente",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Prenotazioni_IDCamera",
                table: "Prenotazioni",
                newName: "IX_Prenotazioni_IDCameraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Camere_IDCameraID",
                table: "Prenotazioni",
                column: "IDCameraID",
                principalTable: "Camere",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Clienti_IDClienteId",
                table: "Prenotazioni",
                column: "IDClienteId",
                principalTable: "Clienti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prenotazioni_Pensioni_IDPensioneID",
                table: "Prenotazioni",
                column: "IDPensioneID",
                principalTable: "Pensioni",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
