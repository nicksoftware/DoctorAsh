using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorAsh.Migrations
{
    public partial class Added_Doctor_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "AppAppointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId1",
                table: "AppAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "AppAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "cancellationReason",
                table: "AppAppointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppDoctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RatingScore = table.Column<double>(type: "float", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDoctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppWorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppWorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppWorkingHours_AppDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AppDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAppointments_DoctorId",
                table: "AppAppointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAppointments_DoctorId1",
                table: "AppAppointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppWorkingHours_DoctorId",
                table: "AppWorkingHours",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId",
                table: "AppAppointments",
                column: "DoctorId",
                principalTable: "AppDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId1",
                table: "AppAppointments",
                column: "DoctorId1",
                principalTable: "AppDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId",
                table: "AppAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId1",
                table: "AppAppointments");

            migrationBuilder.DropTable(
                name: "AppWorkingHours");

            migrationBuilder.DropTable(
                name: "AppDoctors");

            migrationBuilder.DropIndex(
                name: "IX_AppAppointments_DoctorId",
                table: "AppAppointments");

            migrationBuilder.DropIndex(
                name: "IX_AppAppointments_DoctorId1",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "cancellationReason",
                table: "AppAppointments");
        }
    }
}
