using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastChanceAPI.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Lot = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Expiration = table.Column<DateTime>(type: "DATE", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
