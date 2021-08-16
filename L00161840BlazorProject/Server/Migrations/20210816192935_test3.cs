using Microsoft.EntityFrameworkCore.Migrations;

namespace L00161840BlazorProject.Server.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.DropIndex(
                name: "IX_AnnualLeaveRequests_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.DropColumn(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                type: "int",
                nullable: true);

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
        }
    }
}
