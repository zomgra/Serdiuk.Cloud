using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Serdiuk.Cloud.Api.Infrastructure.Migrations
{
    public partial class RemoveDataAndAddFilePathInFileObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Files");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Files",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Files");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Files",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
