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
                name: "ManufacturersData",
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
                    table.PrimaryKey("PK_ManufacturersData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewsData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stars = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoriesData",
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
                    table.PrimaryKey("PK_AccessoriesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessoriesData_ManufacturersData_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessoriesData_ReviewsData_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClothingData",
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
                    table.PrimaryKey("PK_ClothingData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClothingData_ManufacturersData_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClothingData_ReviewsData_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoesData",
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
                    table.PrimaryKey("PK_ShoesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoesData_ManufacturersData_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "ManufacturersData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoesData_ReviewsData_ReviewEntityId",
                        column: x => x.ReviewEntityId,
                        principalTable: "ReviewsData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoriesData_ManufacturerId",
                table: "AccessoriesData",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessoriesData_ReviewEntityId",
                table: "AccessoriesData",
                column: "ReviewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingData_ManufacturerId",
                table: "ClothingData",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ClothingData_ReviewEntityId",
                table: "ClothingData",
                column: "ReviewEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesData_ManufacturerId",
                table: "ShoesData",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoesData_ReviewEntityId",
                table: "ShoesData",
                column: "ReviewEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoriesData");

            migrationBuilder.DropTable(
                name: "ClothingData");

            migrationBuilder.DropTable(
                name: "ShoesData");

            migrationBuilder.DropTable(
                name: "ManufacturersData");

            migrationBuilder.DropTable(
                name: "ReviewsData");
        }
    }
}
