using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseAndMe.Data.Migrations
{
    public partial class cambiar_idsiuadporestado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblCiudades_IdCiudad",
                table: "tblUser");

            migrationBuilder.RenameColumn(
                name: "IdCiudad",
                table: "tblUser",
                newName: "IdEstado");

            migrationBuilder.RenameIndex(
                name: "IX_tblUser_IdCiudad",
                table: "tblUser",
                newName: "IX_tblUser_IdEstado");

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblEstados_IdEstado",
                table: "tblUser",
                column: "IdEstado",
                principalTable: "tblEstados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblEstados_IdEstado",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "tblUser");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "tblUser",
                newName: "IdCiudad");

            migrationBuilder.RenameIndex(
                name: "IX_tblUser_IdEstado",
                table: "tblUser",
                newName: "IX_tblUser_IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblCiudades_IdCiudad",
                table: "tblUser",
                column: "IdCiudad",
                principalTable: "tblCiudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
