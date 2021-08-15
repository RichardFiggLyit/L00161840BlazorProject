using Microsoft.EntityFrameworkCore.Migrations;

namespace L00161840BlazorProject.Server.Migrations
{
    public partial class AnnualLeaveTaken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.CreateTable(
                name: "AnnualLeaveTaken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    AnnualLeaveRequestId = table.Column<int>(type: "int", nullable: true),
                    EntitlementId = table.Column<int>(type: "int", nullable: false),
                    AnnualLeaveEntitlementId = table.Column<int>(type: "int", nullable: true),
                    DaysTaken = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualLeaveTaken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveTaken_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                        column: x => x.AnnualLeaveEntitlementId,
                        principalTable: "AnnualLeaveEntitlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnualLeaveTaken_AnnualLeaveRequests_AnnualLeaveRequestId",
                        column: x => x.AnnualLeaveRequestId,
                        principalTable: "AnnualLeaveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveTaken_AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken",
                column: "AnnualLeaveEntitlementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveTaken_AnnualLeaveRequestId",
                table: "AnnualLeaveTaken",
                column: "AnnualLeaveRequestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnualLeaveTaken");

            migrationBuilder.AddColumn<int>(
                name: "EntitlementId",
                table: "AnnualLeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
