using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LastChance.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Lot = table.Column<string>(type: "TEXT", nullable: false),
                    CodeBar = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    Expiration = table.Column<DateTime>(type: "DATE", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Product", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Product");
        }
    }
}
