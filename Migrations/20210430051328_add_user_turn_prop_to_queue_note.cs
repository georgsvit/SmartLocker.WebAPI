using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class add_user_turn_prop_to_queue_note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserTurn",
                table: "QueueRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserTurn",
                table: "QueueRegister");
        }
    }
}
