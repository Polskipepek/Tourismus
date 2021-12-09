using Microsoft.EntityFrameworkCore.Migrations;

namespace Tourismus.Model.Migrations
{
    public partial class userfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCredentials_Users_UserId",
                table: "UserCredentials");

            migrationBuilder.DropIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCredentials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCredentials_Users_UserId",
                table: "UserCredentials",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCredentials_Users_UserId",
                table: "UserCredentials");

            migrationBuilder.DropIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserCredentials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_UserId",
                table: "UserCredentials",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCredentials_Users_UserId",
                table: "UserCredentials",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
