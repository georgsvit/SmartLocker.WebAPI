using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class add_is_viewed_prop_to_notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "ViolationRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "ServiceRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "QueueRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "AccountingRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "ViolationRegister");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "ServiceRegister");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "QueueRegister");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "AccountingRegister");
        }
    }
}
