using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DivingLogApi.Migrations
{
    public partial class userdivedurationChangedToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "UserDives");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "UserDives",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "UserDives");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "UserDives",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
