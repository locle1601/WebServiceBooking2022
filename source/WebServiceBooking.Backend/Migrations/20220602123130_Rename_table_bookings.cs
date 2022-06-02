using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServiceBooking.Backend.Migrations
{
    public partial class Rename_table_bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Status_StatusId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_StatusId",
                table: "Bookings",
                newName: "IX_Bookings_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Status_StatusId",
                table: "Bookings",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Status_StatusId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_StatusId",
                table: "Categories",
                newName: "IX_Categories_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Status_StatusId",
                table: "Categories",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
