using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBaseAuthBlazor.Data.Migrations
{
    public partial class AddResultsToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Games");
        }
    }
}
