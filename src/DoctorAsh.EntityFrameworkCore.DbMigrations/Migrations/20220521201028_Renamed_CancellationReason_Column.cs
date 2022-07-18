using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorAsh.Migrations
{
    public partial class Renamed_CancellationReason_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cancellationReason",
                table: "AppAppointments",
                newName: "CancellationReason");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CancellationReason",
                table: "AppAppointments",
                newName: "cancellationReason");
        }
    }
}
