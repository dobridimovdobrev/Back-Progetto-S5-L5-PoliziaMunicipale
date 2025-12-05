using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_Progetto_S5_L5_PoliziaMunicipale.Migrations
{
    /// <inheritdoc />
    public partial class Inizilizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anagrafica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Citta = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cap = table.Column<string>(type: "char(5)", maxLength: 5, nullable: false),
                    CodiceFiscale = table.Column<string>(type: "char(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anagrafica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoViolazione",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoViolazione", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Verbale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataViolazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndirizzoViolazione = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NominativoAgente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataTrascizioneVerbale = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Importo = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    DecurtamentoPunti = table.Column<int>(type: "int", nullable: false),
                    IdAnagrafica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTipoViolazione = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verbale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verbale_Anagrafica_IdAnagrafica",
                        column: x => x.IdAnagrafica,
                        principalTable: "Anagrafica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verbale_TipoViolazione_IdTipoViolazione",
                        column: x => x.IdTipoViolazione,
                        principalTable: "TipoViolazione",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_IdAnagrafica",
                table: "Verbale",
                column: "IdAnagrafica");

            migrationBuilder.CreateIndex(
                name: "IX_Verbale_IdTipoViolazione",
                table: "Verbale",
                column: "IdTipoViolazione");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verbale");

            migrationBuilder.DropTable(
                name: "Anagrafica");

            migrationBuilder.DropTable(
                name: "TipoViolazione");
        }
    }
}
