using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBaseAuthBlazor.Data.Migrations
{
    public partial class MoneyChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Money",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Money",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Money");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Money");
        }
    }
}
