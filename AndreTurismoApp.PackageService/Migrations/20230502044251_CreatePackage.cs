using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoApp.PackageService.Migrations
{
    public partial class CreatePackage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_CustomerId",
                table: "Package",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_HotelId",
                table: "Package",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_TicketId",
                table: "Package",
                column: "TicketId");            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
