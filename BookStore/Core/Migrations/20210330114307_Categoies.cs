using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Categoies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_reviews_Book_reviewsId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "Book_reviews");

            migrationBuilder.RenameColumn(
                name: "Book_reviewsId",
                table: "Review",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_Book_reviewsId",
                table: "Review",
                newName: "IX_Review_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Books_BookId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Review",
                newName: "Book_reviewsId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookId",
                table: "Review",
                newName: "IX_Review_Book_reviewsId");

            migrationBuilder.CreateTable(
                name: "Book_reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_reviews_BookId",
                table: "Book_reviews",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_reviews_Book_reviewsId",
                table: "Review",
                column: "Book_reviewsId",
                principalTable: "Book_reviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
