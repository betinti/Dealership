using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackOfficeConcessionaria.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Sellers_SellerId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_SellerId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Owners");

            migrationBuilder.AddColumn<DateTime>(
                name: "BuyDate",
                table: "Sales",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Owners_UserId",
                table: "Owners",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Users_UserId",
                table: "Owners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Users_UserId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_UserId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "BuyDate",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Owners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_SellerId",
                table: "Owners",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Sellers_SellerId",
                table: "Owners",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id");
        }
    }
}
