using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackOfficeConcessionaria.Migrations
{
    public partial class AddUserIdAtSellerAndOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Sellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Owners");
        }
    }
}
