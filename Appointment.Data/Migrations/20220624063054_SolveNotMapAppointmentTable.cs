using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Data.Migrations
{
    public partial class SolveNotMapAppointmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "AppointmentTimes");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_UserId",
                table: "AppointmentTimes",
                newName: "IX_AppointmentTimes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppontmentTime",
                table: "AppointmentTimes",
                newName: "IX_AppointmentTimes_AppontmentTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentTimes",
                table: "AppointmentTimes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentTimes_AspNetUsers_UserId",
                table: "AppointmentTimes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentTimes_AspNetUsers_UserId",
                table: "AppointmentTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentTimes",
                table: "AppointmentTimes");

            migrationBuilder.RenameTable(
                name: "AppointmentTimes",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTimes_UserId",
                table: "Appointments",
                newName: "IX_Appointments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentTimes_AppontmentTime",
                table: "Appointments",
                newName: "IX_Appointments_AppontmentTime");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_UserId",
                table: "Appointments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
