using Microsoft.EntityFrameworkCore.Migrations;

namespace L00161840BlazorProject.Server.Migrations
{
    public partial class AnnualLeaveTakenv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveTaken_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken");

            migrationBuilder.DropIndex(
                name: "IX_AnnualLeaveTaken_AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken");

            migrationBuilder.DropIndex(
                name: "IX_AnnualLeaveRequests_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.DropColumn(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken");

            migrationBuilder.DropColumn(
                name: "EntitlementId",
                table: "AnnualLeaveTaken");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "AnnualLeaveTaken");

            migrationBuilder.DropColumn(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntitlementId",
                table: "AnnualLeaveTaken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "AnnualLeaveTaken",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveTaken_AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken",
                column: "AnnualLeaveEntitlementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualLeaveRequests_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                column: "AnnualLeaveEntitlementId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                column: "AnnualLeaveEntitlementId",
                principalTable: "AnnualLeaveEntitlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualLeaveTaken_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveTaken",
                column: "AnnualLeaveEntitlementId",
                principalTable: "AnnualLeaveEntitlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
