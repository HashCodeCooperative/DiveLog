using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DivingLogApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiveSites",
                columns: table => new
                {
                    DiveSiteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    GPSPosition = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiveSites", x => x.DiveSiteId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    isRegistered = table.Column<bool>(type: "INTEGER", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Dives",
                columns: table => new
                {
                    DiveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DiveType = table.Column<int>(type: "INTEGER", nullable: false),
                    Water = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterStream = table.Column<int>(type: "INTEGER", nullable: false),
                    Weather = table.Column<int>(type: "INTEGER", nullable: false),
                    AirTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    WaterTemp = table.Column<int>(type: "INTEGER", nullable: false),
                    Visibility = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DiveSiteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dives", x => x.DiveId);
                    table.ForeignKey(
                        name: "FK_Dives_DiveSites_DiveSiteId",
                        column: x => x.DiveSiteId,
                        principalTable: "DiveSites",
                        principalColumn: "DiveSiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDives",
                columns: table => new
                {
                    UserDiveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DivingSuit = table.Column<int>(type: "INTEGER", nullable: false),
                    Gas = table.Column<int>(type: "INTEGER", nullable: false),
                    CylinderType = table.Column<int>(type: "INTEGER", nullable: false),
                    CylinderCapacity = table.Column<int>(type: "INTEGER", nullable: false),
                    CylStartPressure = table.Column<int>(type: "INTEGER", nullable: false),
                    CylEndPressure = table.Column<int>(type: "INTEGER", nullable: false),
                    SurfaceAirConsumption = table.Column<float>(type: "REAL", nullable: false),
                    MaxDepth = table.Column<float>(type: "REAL", nullable: false),
                    AvgDepth = table.Column<float>(type: "REAL", nullable: false),
                    Ballast = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DiveId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDives", x => x.UserDiveId);
                    table.ForeignKey(
                        name: "FK_UserDives_Dives_DiveId",
                        column: x => x.DiveId,
                        principalTable: "Dives",
                        principalColumn: "DiveId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dives_DiveSiteId",
                table: "Dives",
                column: "DiveSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDives_DiveId",
                table: "UserDives",
                column: "DiveId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDives_UserId",
                table: "UserDives",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDives");

            migrationBuilder.DropTable(
                name: "Dives");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DiveSites");
        }
    }
}
