using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banques",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banques", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DABs",
                columns: table => new
                {
                    DABId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Loacalisation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DABs", x => x.DABId);
                });

            migrationBuilder.CreateTable(
                name: "Comptes",
                columns: table => new
                {
                    NumeroCompte = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Proprietaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BanqueFk = table.Column<int>(type: "int", nullable: false),
                    banqueCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comptes", x => x.NumeroCompte);
                    table.ForeignKey(
                        name: "FK_Comptes_Banques_banqueCode",
                        column: x => x.banqueCode,
                        principalTable: "Banques",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroCompteFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DABFk = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Montant = table.Column<double>(type: "float", nullable: false),
                    Descriminator = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    NumeroCompte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutreAgence = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => new { x.NumeroCompteFk, x.DABFk, x.Date });
                    table.ForeignKey(
                        name: "FK_Transactions_Comptes_NumeroCompteFk",
                        column: x => x.NumeroCompteFk,
                        principalTable: "Comptes",
                        principalColumn: "NumeroCompte",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_DABs_DABFk",
                        column: x => x.DABFk,
                        principalTable: "DABs",
                        principalColumn: "DABId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comptes_banqueCode",
                table: "Comptes",
                column: "banqueCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DABFk",
                table: "Transactions",
                column: "DABFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Comptes");

            migrationBuilder.DropTable(
                name: "DABs");

            migrationBuilder.DropTable(
                name: "Banques");
        }
    }
}
