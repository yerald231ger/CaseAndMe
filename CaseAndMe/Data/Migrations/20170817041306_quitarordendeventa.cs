using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseAndMe.Data.Migrations
{
    public partial class quitarordendeventa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdOrdenVenta",
                table: "tblUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdOrdenVenta",
                table: "tblUser",
                nullable: false,
                defaultValue: 0);
        }
    }
}
