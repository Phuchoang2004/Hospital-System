using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class removebook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketStretcher");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "LoanManagement");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "Book_Category");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorID = table.Column<int>(type: "int", nullable: false),
                    AverageScore = table.Column<double>(type: "float", nullable: false),
                    BackCoverText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnLoan = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Recommended = table.Column<bool>(type: "bit", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book_Category",
                columns: table => new
                {
                    KKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Book_CategoryKKID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Category", x => x.KKID);
                    table.ForeignKey(
                        name: "FK_Book_Category_Book_Category_Book_CategoryKKID",
                        column: x => x.Book_CategoryKKID,
                        principalTable: "Book_Category",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Book_Category_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketStretcher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Book_CategoryKKID = table.Column<int>(type: "int", nullable: true),
                    FullName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketStretcher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BasketStretcher_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketStretcher_Book_Category_Book_CategoryKKID",
                        column: x => x.Book_CategoryKKID,
                        principalTable: "Book_Category",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_BasketStretcher_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Book_CategoryKKID = table.Column<int>(type: "int", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Book_Category_Book_CategoryKKID",
                        column: x => x.Book_CategoryKKID,
                        principalTable: "Book_Category",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanManagement",
                columns: table => new
                {
                    LoanManagementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Book_CategoryKKID = table.Column<int>(type: "int", nullable: true),
                    DefaultDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanManagement", x => x.LoanManagementID);
                    table.ForeignKey(
                        name: "FK_LoanManagement_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanManagement_Book_Category_Book_CategoryKKID",
                        column: x => x.Book_CategoryKKID,
                        principalTable: "Book_Category",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_LoanManagement_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Book_CategoryKKID = table.Column<int>(type: "int", nullable: true),
                    History = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointID);
                    table.ForeignKey(
                        name: "FK_Points_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_Book_Category_Book_CategoryKKID",
                        column: x => x.Book_CategoryKKID,
                        principalTable: "Book_Category",
                        principalColumn: "KKID");
                    table.ForeignKey(
                        name: "FK_Points_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketStretcher_Book_CategoryKKID",
                table: "BasketStretcher",
                column: "Book_CategoryKKID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketStretcher_BookID",
                table: "BasketStretcher",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_BasketStretcher_UserID",
                table: "BasketStretcher",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category_Book_CategoryKKID",
                table: "Book_Category",
                column: "Book_CategoryKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category_BookID",
                table: "Book_Category",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Category_CategoryID",
                table: "Book_Category",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Book_CategoryKKID",
                table: "Comments",
                column: "Book_CategoryKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookID",
                table: "Comments",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserID",
                table: "Comments",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanManagement_Book_CategoryKKID",
                table: "LoanManagement",
                column: "Book_CategoryKKID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanManagement_BookID",
                table: "LoanManagement",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanManagement_UserID",
                table: "LoanManagement",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_Book_CategoryKKID",
                table: "Points",
                column: "Book_CategoryKKID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_BookID",
                table: "Points",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_UserID",
                table: "Points",
                column: "UserID");
        }
    }
}
