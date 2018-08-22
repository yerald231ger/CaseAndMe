using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CaseAndMe.Data.Migrations
{
    public partial class camposParaElUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CiudadId",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlt",
                table: "tblUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaMod",
                table: "tblUser",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdCiudad",
                table: "tblUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "tblUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono2",
                table: "tblUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryISO = table.Column<string>(nullable: true),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    IdPais = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    EstadoId = table.Column<int>(nullable: true),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudad_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_CiudadId",
                table: "tblUser",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_EstadoId",
                table: "Ciudad",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_Ciudad_CiudadId",
                table: "tblUser",
                column: "CiudadId",
                principalTable: "Ciudad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_Ciudad_CiudadId",
                table: "tblUser");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_CiudadId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "CiudadId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "FechaAlt",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "FechaMod",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "IdCiudad",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "Telefono2",
                table: "tblUser");
        }
    }
}
