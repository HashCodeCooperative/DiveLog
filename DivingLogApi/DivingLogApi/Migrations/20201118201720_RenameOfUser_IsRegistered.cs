using Microsoft.EntityFrameworkCore.Migrations;

namespace DivingLogApi.Migrations
{
    public partial class RenameOfUser_IsRegistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isRegistered",
                table: "Users",
                newName: "IsRegistered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRegistered",
                table: "Users",
                newName: "isRegistered");
        }
    }
}
