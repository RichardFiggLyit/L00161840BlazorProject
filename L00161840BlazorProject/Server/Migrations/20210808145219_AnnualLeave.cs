using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace L00161840BlazorProject.Server.Migrations
{
    public partial class AnnualLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Invites_EmployeeId",
                table: "Invites");

            migrationBuilder.CreateTable(
                name: "AnnualLeaveEntitlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaxYear = table.Column<int>(type: "int", nullable: false),
                    Entitlment = table.Column<int>(type: "int", nullable: false),
                    Taken = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualLeaveEntitlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveEntitlements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnualLeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EntitlementId = table.Column<int>(type: "int", nullable: false),
                    AnnualLeaveEntitlementId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysTaken = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RequestedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSetBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusSetTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualLeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                        column: x => x.AnnualLeaveEntitlementId,
                        principalTable: "AnnualLeaveEntitlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invites_EmployeeId",
                table: "Invites",
                column: "EmployeeId",
                unique: true,
                filter: "[EmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveEntitlements_EmployeeId",
                table: "AnnualLeaveEntitlements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveRequests_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                column: "AnnualLeaveEntitlementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveRequests_EmployeeId",
                table: "AnnualLeaveRequests",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualLeaveRequests");

            migrationBuilder.DropTable(
                name: "AnnualLeaveEntitlements");

            migrationBuilder.DropIndex(
                name: "IX_Invites_EmployeeId",
                table: "Invites");

            migrationBuilder.CreateIndex(
                name: "IX_Invites_EmployeeId",
                table: "Invites",
                column: "EmployeeId");
        }
    }
}
