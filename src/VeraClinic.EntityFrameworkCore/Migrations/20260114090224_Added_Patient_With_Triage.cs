using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeraClinic.Migrations
{
    /// <inheritdoc />
    public partial class Added_Patient_With_Triage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppPatients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Surname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IdentityNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CurrentTriageStatus = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Complaint = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    LastBodyTemperature = table.Column<double>(type: "double precision", nullable: true),
                    LastHeartRate = table.Column<int>(type: "integer", nullable: true),
                    LastBloodPressure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LastOxygenSaturation = table.Column<int>(type: "integer", nullable: true),
                    IsInEmergencyRoom = table.Column<bool>(type: "boolean", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPatients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppPatients_IdentityNumber",
                table: "AppPatients",
                column: "IdentityNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppPatients");
        }
    }
}
