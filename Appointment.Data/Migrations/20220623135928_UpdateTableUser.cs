using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Data.Migrations
{
    public partial class UpdateTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DateOfAppointment",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DateOfAppointment",
                table: "AspNetUsers",
                newName: "DateOfAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfAccount",
                table: "AspNetUsers",
                newName: "DateOfAppointment");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DateOfAppointment",
                table: "AspNetUsers",
                column: "DateOfAppointment",
                unique: true,
                filter: "[DateOfAppointment] IS NOT NULL");
        }
    }
}
