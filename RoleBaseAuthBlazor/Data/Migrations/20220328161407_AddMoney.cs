using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBaseAuthBlazor.Data.Migrations
{
    public partial class AddMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Money_MoneyyId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Money_AspNetUsers_BlazorUserId",
                table: "Money");

            migrationBuilder.DropIndex(
                name: "IX_Money_BlazorUserId",
                table: "Money");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MoneyyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BlazorUserId",
                table: "Money");

            migrationBuilder.DropColumn(
                name: "MoneyyId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "BlazorUserMoney",
                columns: table => new
                {
                    BlazorUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MoneyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlazorUserMoney", x => new { x.BlazorUsersId, x.MoneyId });
                    table.ForeignKey(
                        name: "FK_BlazorUserMoney_AspNetUsers_BlazorUsersId",
                        column: x => x.BlazorUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlazorUserMoney_Money_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlazorUserMoney_MoneyId",
                table: "BlazorUserMoney",
                column: "MoneyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlazorUserMoney");

            migrationBuilder.AddColumn<string>(
                name: "BlazorUserId",
                table: "Money",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MoneyyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Money_BlazorUserId",
                table: "Money",
                column: "BlazorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MoneyyId",
                table: "AspNetUsers",
                column: "MoneyyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Money_MoneyyId",
                table: "AspNetUsers",
                column: "MoneyyId",
                principalTable: "Money",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Money_AspNetUsers_BlazorUserId",
                table: "Money",
                column: "BlazorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
