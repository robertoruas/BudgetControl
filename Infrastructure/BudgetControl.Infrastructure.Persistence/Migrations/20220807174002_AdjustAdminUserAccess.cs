using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgetControl.Infrastructure.Persistence.Migrations
{
    public partial class AdjustAdminUserAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "36E20BC1D942350374ADF4F44AEC4DA43B0F2AD4AFB581BB659AD9ECB8114D8A77568850CAF6033905237EF6023CDA9D808CE102F7BD76575E119F832C3FE01D");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "6FB3E8200EB5EFE167679EF9326F7CD5A814ABE24CC6EFA777DD168FE8379B50CCDA08627091D676C0AC0F22954812EF93F9C2454CCDB6A5001052A071FE5569");
        }
    }
}
