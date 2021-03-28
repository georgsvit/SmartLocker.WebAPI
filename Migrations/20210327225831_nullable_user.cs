using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLocker.WebAPI.Migrations
{
    public partial class nullable_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ViolationRegister",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ServiceRegister",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "QueueRegister",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AccountingRegister",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationRegister_UserId",
                table: "ViolationRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRegister_UserId",
                table: "ServiceRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueRegister_UserId",
                table: "QueueRegister",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountingRegister_UserId",
                table: "AccountingRegister",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountingRegister_Users_UserId",
                table: "AccountingRegister",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QueueRegister_Users_UserId",
                table: "QueueRegister",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRegister_Users_UserId",
                table: "ServiceRegister",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ViolationRegister_Users_UserId",
                table: "ViolationRegister",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountingRegister_Users_UserId",
                table: "AccountingRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_QueueRegister_Users_UserId",
                table: "QueueRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRegister_Users_UserId",
                table: "ServiceRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_ViolationRegister_Users_UserId",
                table: "ViolationRegister");

            migrationBuilder.DropIndex(
                name: "IX_ViolationRegister_UserId",
                table: "ViolationRegister");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRegister_UserId",
                table: "ServiceRegister");

            migrationBuilder.DropIndex(
                name: "IX_QueueRegister_UserId",
                table: "QueueRegister");

            migrationBuilder.DropIndex(
                name: "IX_AccountingRegister_UserId",
                table: "AccountingRegister");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ViolationRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "ServiceRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "QueueRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AccountingRegister",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
