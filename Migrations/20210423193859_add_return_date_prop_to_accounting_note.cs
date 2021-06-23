using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class add_return_date_prop_to_accounting_note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "AccountingRegister");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "AccountingRegister",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "AccountingRegister");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "AccountingRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
