using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicStore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    producerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producerPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producers", x => x.producerID);
                });

            migrationBuilder.CreateTable(
                name: "sellers",
                columns: table => new
                {
                    sellerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sellerPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sellerDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sellers", x => x.sellerID);
                });

            migrationBuilder.CreateTable(
                name: "warranties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warrantyPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warrantyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    warrantyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warranties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productPrice = table.Column<double>(type: "float", nullable: false),
                    productPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producyListDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productCategory = table.Column<int>(type: "int", nullable: false),
                    sellerID = table.Column<int>(type: "int", nullable: false),
                    producerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productID);
                    table.ForeignKey(
                        name: "FK_products_producers_producerID",
                        column: x => x.producerID,
                        principalTable: "producers",
                        principalColumn: "producerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_sellers_sellerID",
                        column: x => x.sellerID,
                        principalTable: "sellers",
                        principalColumn: "sellerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "warrantytoProducts",
                columns: table => new
                {
                    productID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warrantytoProducts", x => new { x.Id, x.productID });
                    table.ForeignKey(
                        name: "FK_warrantytoProducts_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warrantytoProducts_warranties_Id",
                        column: x => x.Id,
                        principalTable: "warranties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_producerID",
                table: "products",
                column: "producerID");

            migrationBuilder.CreateIndex(
                name: "IX_products_sellerID",
                table: "products",
                column: "sellerID");

            migrationBuilder.CreateIndex(
                name: "IX_warrantytoProducts_productID",
                table: "warrantytoProducts",
                column: "productID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "warrantytoProducts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "warranties");

            migrationBuilder.DropTable(
                name: "producers");

            migrationBuilder.DropTable(
                name: "sellers");
        }
    }
}
