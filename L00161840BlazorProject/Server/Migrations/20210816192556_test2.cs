using Microsoft.EntityFrameworkCore.Migrations;

namespace L00161840BlazorProject.Server.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.DropColumn(
                name: "AnnualLeaveRequestId",
                table: "AnnualLeaveEntitlements");

            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                column: "AnnualLeaveEntitlementId",
                principalTable: "AnnualLeaveEntitlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests");

            migrationBuilder.AlterColumn<int>(
                name: "AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnnualLeaveRequestId",
                table: "AnnualLeaveEntitlements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AnnualLeaveRequests_AnnualLeaveEntitlements_AnnualLeaveEntitlementId",
                table: "AnnualLeaveRequests",
                column: "AnnualLeaveEntitlementId",
                principalTable: "AnnualLeaveEntitlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
