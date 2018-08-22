using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CaseAndMe.Data.Migrations
{
    public partial class quitarTablaProductosSubCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductosSubCategorias");

            migrationBuilder.AddColumn<int>(
                name: "IdSubCategoria",
                table: "tblProductos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tblProductos_IdSubCategoria",
                table: "tblProductos",
                column: "IdSubCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductos_tblSubCategorias_IdSubCategoria",
                table: "tblProductos",
                column: "IdSubCategoria",
                principalTable: "tblSubCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductos_tblSubCategorias_IdSubCategoria",
                table: "tblProductos");

            migrationBuilder.DropIndex(
                name: "IX_tblProductos_IdSubCategoria",
                table: "tblProductos");

            migrationBuilder.DropColumn(
                name: "IdSubCategoria",
                table: "tblProductos");

            migrationBuilder.CreateTable(
                name: "tblProductosSubCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    IdSubCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductosSubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductosSubCategorias_tblProductos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "tblProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                        column: x => x.IdSubCategoria,
                        principalTable: "tblSubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductosSubCategorias_IdProducto",
                table: "tblProductosSubCategorias",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductosSubCategorias_IdSubCategoria",
                table: "tblProductosSubCategorias",
                column: "IdSubCategoria");
        }
    }
}
