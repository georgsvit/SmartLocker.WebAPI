using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class model_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeBetweenServices",
                table: "ServiceBooks");

            migrationBuilder.AddColumn<long>(
                name: "MsBetweenServices",
                table: "ServiceBooks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MsBetweenServices",
                table: "ServiceBooks");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeBetweenServices",
                table: "ServiceBooks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
