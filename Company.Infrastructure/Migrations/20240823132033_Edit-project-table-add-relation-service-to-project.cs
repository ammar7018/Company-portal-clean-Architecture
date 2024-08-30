using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Editprojecttableaddrelationservicetoproject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectServices",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectServices", x => new { x.ProjectId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ProjectServices_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Cost", "CreationDate", "Description", "DriveLink", "EndDate", "Name", "status" },
                values: new object[,]
                {
                    { 1, 150000, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Researching AI applications in healthcare.", "https://drive.google.com/samplelink1", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI Research Project", null },
                    { 2, 75000, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing an e-commerce website.", "https://drive.google.com/samplelink2", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Development Project", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectServices_ServiceId",
                table: "ProjectServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectServices");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "status",
                table: "Projects");
        }
    }
}
