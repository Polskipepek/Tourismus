using Microsoft.EntityFrameworkCore.Migrations;

namespace Tourismus.Model.Migrations
{
    public partial class FkFixesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId1",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cities_CityId1",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Hotels_HotelId1",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Meals_MealId1",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Offers_OfferId1",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OfferId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CityId1",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_HotelId1",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_MealId1",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Cities_CountryId1",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "OfferId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "HotelId1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "MealId1",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "Cities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelId1",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MealId1",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OfferId1",
                table: "Reservations",
                column: "OfferId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId1",
                table: "Reservations",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CityId1",
                table: "Offers",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_HotelId1",
                table: "Offers",
                column: "HotelId1");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_MealId1",
                table: "Offers",
                column: "MealId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId1",
                table: "Cities",
                column: "CountryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId1",
                table: "Cities",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cities_CityId1",
                table: "Offers",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Hotels_HotelId1",
                table: "Offers",
                column: "HotelId1",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Meals_MealId1",
                table: "Offers",
                column: "MealId1",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Offers_OfferId1",
                table: "Reservations",
                column: "OfferId1",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId1",
                table: "Reservations",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
