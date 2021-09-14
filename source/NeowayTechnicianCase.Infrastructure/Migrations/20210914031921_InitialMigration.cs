using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NeowayTechnicianCase.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    CNPJIsValid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: true),
                    CPFIsValid = table.Column<bool>(type: "boolean", nullable: false),
                    Private = table.Column<bool>(type: "boolean", nullable: false),
                    Unfinished = table.Column<bool>(type: "boolean", nullable: false),
                    LastPurchase = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MediumTicket = table.Column<double>(type: "double precision", nullable: true),
                    LastPurchaseTicket = table.Column<double>(type: "double precision", nullable: true),
                    UsualStoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastStoreId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Stores_LastStoreId",
                        column: x => x.LastStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchases_Stores_UsualStoreId",
                        column: x => x.UsualStoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_LastStoreId",
                table: "Purchases",
                column: "LastStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UsualStoreId",
                table: "Purchases",
                column: "UsualStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
