using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vasiliu_Adrian_Lab2.Migrations
{
    public partial class AthorModification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
