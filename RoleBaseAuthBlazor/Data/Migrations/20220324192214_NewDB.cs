using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBaseAuthBlazor.Data.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoneyyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlazorUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Money_AspNetUsers_BlazorUserId",
                        column: x => x.BlazorUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MoneyyId",
                table: "AspNetUsers",
                column: "MoneyyId");

            migrationBuilder.CreateIndex(
                name: "IX_Money_BlazorUserId",
                table: "Money",
                column: "BlazorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Money_MoneyyId",
                table: "AspNetUsers",
                column: "MoneyyId",
                principalTable: "Money",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Money_MoneyyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MoneyyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MoneyyId",
                table: "AspNetUsers");
        }
    }
}
