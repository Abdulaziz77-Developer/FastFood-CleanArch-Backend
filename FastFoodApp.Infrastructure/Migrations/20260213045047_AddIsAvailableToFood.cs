using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsAvailableToFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Foods",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Foods");
        }
    }
}
