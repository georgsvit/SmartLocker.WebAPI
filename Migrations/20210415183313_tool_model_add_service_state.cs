using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class tool_model_add_service_state : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceState",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceState",
                table: "Tools");
        }
    }
}
