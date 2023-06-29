using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Serdiuk.Cloud.Api.Infrastructure.Migrations
{
    public partial class AddIsPublicInFileObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "Files",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "Files");
        }
    }
}
