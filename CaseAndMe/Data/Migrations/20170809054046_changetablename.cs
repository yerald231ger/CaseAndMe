using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaseAndMe.Data.Migrations
{
    public partial class changetablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrdenesVenta_MetodosEnvios_IdMetodoEnvio",
                table: "tblOrdenesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrdenesVenta_MetodosPagos_IdMetodoPago",
                table: "tblOrdenesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosSubCategorias_tblProductos_IdProducto",
                table: "ProductosSubCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                table: "ProductosSubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductosSubCategorias",
                table: "ProductosSubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetodosPagos",
                table: "MetodosPagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetodosEnvios",
                table: "MetodosEnvios");

            migrationBuilder.RenameTable(
                name: "ProductosSubCategorias",
                newName: "tblProductosSubCategorias");

            migrationBuilder.RenameTable(
                name: "MetodosPagos",
                newName: "tblMetodosPago");

            migrationBuilder.RenameTable(
                name: "MetodosEnvios",
                newName: "tblMetodosEnvio");

            migrationBuilder.RenameIndex(
                name: "IX_ProductosSubCategorias_IdSubCategoria",
                table: "tblProductosSubCategorias",
                newName: "IX_tblProductosSubCategorias_IdSubCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_ProductosSubCategorias_IdProducto",
                table: "tblProductosSubCategorias",
                newName: "IX_tblProductosSubCategorias_IdProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblProductosSubCategorias",
                table: "tblProductosSubCategorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMetodosPago",
                table: "tblMetodosPago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblMetodosEnvio",
                table: "tblMetodosEnvio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrdenesVenta_tblMetodosEnvio_IdMetodoEnvio",
                table: "tblOrdenesVenta",
                column: "IdMetodoEnvio",
                principalTable: "tblMetodosEnvio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrdenesVenta_tblMetodosPago_IdMetodoPago",
                table: "tblOrdenesVenta",
                column: "IdMetodoPago",
                principalTable: "tblMetodosPago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductosSubCategorias_tblProductos_IdProducto",
                table: "tblProductosSubCategorias",
                column: "IdProducto",
                principalTable: "tblProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                table: "tblProductosSubCategorias",
                column: "IdSubCategoria",
                principalTable: "tblSubCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrdenesVenta_tblMetodosEnvio_IdMetodoEnvio",
                table: "tblOrdenesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrdenesVenta_tblMetodosPago_IdMetodoPago",
                table: "tblOrdenesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductosSubCategorias_tblProductos_IdProducto",
                table: "tblProductosSubCategorias");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                table: "tblProductosSubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblProductosSubCategorias",
                table: "tblProductosSubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMetodosPago",
                table: "tblMetodosPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblMetodosEnvio",
                table: "tblMetodosEnvio");

            migrationBuilder.RenameTable(
                name: "tblProductosSubCategorias",
                newName: "ProductosSubCategorias");

            migrationBuilder.RenameTable(
                name: "tblMetodosPago",
                newName: "MetodosPagos");

            migrationBuilder.RenameTable(
                name: "tblMetodosEnvio",
                newName: "MetodosEnvios");

            migrationBuilder.RenameIndex(
                name: "IX_tblProductosSubCategorias_IdSubCategoria",
                table: "ProductosSubCategorias",
                newName: "IX_ProductosSubCategorias_IdSubCategoria");

            migrationBuilder.RenameIndex(
                name: "IX_tblProductosSubCategorias_IdProducto",
                table: "ProductosSubCategorias",
                newName: "IX_ProductosSubCategorias_IdProducto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductosSubCategorias",
                table: "ProductosSubCategorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetodosPagos",
                table: "MetodosPagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetodosEnvios",
                table: "MetodosEnvios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrdenesVenta_MetodosEnvios_IdMetodoEnvio",
                table: "tblOrdenesVenta",
                column: "IdMetodoEnvio",
                principalTable: "MetodosEnvios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrdenesVenta_MetodosPagos_IdMetodoPago",
                table: "tblOrdenesVenta",
                column: "IdMetodoPago",
                principalTable: "MetodosPagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosSubCategorias_tblProductos_IdProducto",
                table: "ProductosSubCategorias",
                column: "IdProducto",
                principalTable: "tblProductos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                table: "ProductosSubCategorias",
                column: "IdSubCategoria",
                principalTable: "tblSubCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
