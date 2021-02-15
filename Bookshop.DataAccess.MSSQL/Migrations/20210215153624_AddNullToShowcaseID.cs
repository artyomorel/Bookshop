using Microsoft.EntityFrameworkCore.Migrations;

namespace Bookshop.DataAccess.MSSQL.Migrations
{
    public partial class AddNullToShowcaseID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Showcases_ShowcaseId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShowcaseId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Showcases_ShowcaseId",
                table: "Books",
                column: "ShowcaseId",
                principalTable: "Showcases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Showcases_ShowcaseId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "ShowcaseId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Showcases_ShowcaseId",
                table: "Books",
                column: "ShowcaseId",
                principalTable: "Showcases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
