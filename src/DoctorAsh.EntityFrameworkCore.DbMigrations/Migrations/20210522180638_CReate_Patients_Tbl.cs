using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorAsh.Migrations
{
    public partial class CReate_Patients_Tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId1",
                table: "AppAppointments");

            migrationBuilder.DropIndex(
                name: "IX_AppAppointments_DoctorId1",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "AppAppointments");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "AppAppointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AppPatients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppAppointments_PatientId",
                table: "AppAppointments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAppointments_AppPatients_PatientId",
                table: "AppAppointments",
                column: "PatientId",
                principalTable: "AppPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAppointments_AppPatients_PatientId",
                table: "AppAppointments");

            migrationBuilder.DropTable(
                name: "AppPatients");

            migrationBuilder.DropIndex(
                name: "IX_AppAppointments_PatientId",
                table: "AppAppointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "AppAppointments");

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId1",
                table: "AppAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppAppointments_DoctorId1",
                table: "AppAppointments",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAppointments_AppDoctors_DoctorId1",
                table: "AppAppointments",
                column: "DoctorId1",
                principalTable: "AppDoctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
