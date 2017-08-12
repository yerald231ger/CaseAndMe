using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseAndMe.Data.Migrations
{
    public partial class camposnuevosparaelsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_Ciudad_CiudadId",
                table: "tblUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Estado_EstadoId",
                table: "Ciudad");

            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais_PaisId",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pais",
                table: "Pais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estado",
                table: "Estado");

            migrationBuilder.DropIndex(
                name: "IX_Estado_PaisId",
                table: "Estado");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_Ciudad_EstadoId",
                table: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_CiudadId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "Pais",
                newName: "tblPaises");

            migrationBuilder.RenameTable(
                name: "Estado",
                newName: "tblEstados");

            migrationBuilder.RenameTable(
                name: "Ciudad",
                newName: "tblCiudades");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPaises",
                table: "tblPaises",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblEstados",
                table: "tblEstados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCiudades",
                table: "tblCiudades",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblEstados_IdPais",
                table: "tblEstados",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_tblCiudades_IdEstado",
                table: "tblCiudades",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_IdCiudad",
                table: "tblUser",
                column: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblCiudades_IdCiudad",
                table: "tblUser",
                column: "IdCiudad",
                principalTable: "tblCiudades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCiudades_tblEstados_IdEstado",
                table: "tblCiudades",
                column: "IdEstado",
                principalTable: "tblEstados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEstados_tblPaises_IdPais",
                table: "tblEstados",
                column: "IdPais",
                principalTable: "tblPaises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblCiudades_IdCiudad",
                table: "tblUser");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCiudades_tblEstados_IdEstado",
                table: "tblCiudades");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEstados_tblPaises_IdPais",
                table: "tblEstados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPaises",
                table: "tblPaises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblEstados",
                table: "tblEstados");

            migrationBuilder.DropIndex(
                name: "IX_tblEstados_IdPais",
                table: "tblEstados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCiudades",
                table: "tblCiudades");

            migrationBuilder.DropIndex(
                name: "IX_tblCiudades_IdEstado",
                table: "tblCiudades");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_IdCiudad",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblPaises",
                newName: "Pais");

            migrationBuilder.RenameTable(
                name: "tblEstados",
                newName: "Estado");

            migrationBuilder.RenameTable(
                name: "tblCiudades",
                newName: "Ciudad");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Estado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "Ciudad",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pais",
                table: "Pais",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estado",
                table: "Estado",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_EstadoId",
                table: "Ciudad",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_CiudadId",
                table: "tblUser",
                column: "CiudadId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_Ciudad_CiudadId",
                table: "tblUser",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Estado_EstadoId",
                table: "Ciudad",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais_PaisId",
                table: "Estado",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
