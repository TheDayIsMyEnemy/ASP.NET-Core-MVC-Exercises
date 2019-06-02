using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Infrastructure.Migrations
{
    public partial class Book_ReleaseDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "Books");
        }
    }
}
