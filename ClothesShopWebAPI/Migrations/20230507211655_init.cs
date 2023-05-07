using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothesShopWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturerEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stars = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoriesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryAccessories = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoriesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoriesEntities_ManufacturerEntity_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturerEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoriesEntities_ReviewEntity_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothingEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryClothing = table.Column<int>(type: "int", nullable: false),
                    SizeClothing = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingEntities_ManufacturerEntity_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturerEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingEntities_ReviewEntity_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoesEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Stock = table.Column<long>(type: "bigint", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryShoes = table.Column<int>(type: "int", nullable: false),
                    SizeShoes = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoesEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesEntities_ManufacturerEntity_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturerEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoesEntities_ReviewEntity_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoriesEntities_ManufacturerId",
                table: "AccessoriesEntities",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoriesEntities_ReviewEntityId",
                table: "AccessoriesEntities",
                column: "ReviewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingEntities_ManufacturerId",
                table: "ClothingEntities",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingEntities_ReviewEntityId",
                table: "ClothingEntities",
                column: "ReviewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesEntities_ManufacturerId",
                table: "ShoesEntities",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesEntities_ReviewEntityId",
                table: "ShoesEntities",
                column: "ReviewEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoriesEntities");

            migrationBuilder.DropTable(
                name: "ClothingEntities");

            migrationBuilder.DropTable(
                name: "ShoesEntities");

            migrationBuilder.DropTable(
                name: "ManufacturerEntity");

            migrationBuilder.DropTable(
                name: "ReviewEntity");
        }
    }
}
