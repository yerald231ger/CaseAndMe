using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CaseAndMe.Data.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "tblUserToken");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "tblUserRole");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "tblUserLogin");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "tblUserClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "tblRoleClaim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "tblRole");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "tblUser");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "tblUserRole",
                newName: "IX_tblUserRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "tblUserLogin",
                newName: "IX_tblUserLogin_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "tblUserClaim",
                newName: "IX_tblUserClaim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "tblRoleClaim",
                newName: "IX_tblRoleClaim_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "IdOrdenVenta",
                table: "tblUser",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserToken",
                table: "tblUserToken",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserRole",
                table: "tblUserRole",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserLogin",
                table: "tblUserLogin",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUserClaim",
                table: "tblUserClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRoleClaim",
                table: "tblRoleClaim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "tblCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodosEnvios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosEnvios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodosPagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodosPagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProductos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Precio = table.Column<float>(nullable: false),
                    UrlImagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSubCategorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    IdCategoria = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblSubCategorias_tblCategorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "tblCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrdenesVenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    Folio = table.Column<string>(nullable: true),
                    IdMetodoEnvio = table.Column<int>(nullable: false),
                    IdMetodoPago = table.Column<int>(nullable: false),
                    IdUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrdenesVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrdenesVenta_MetodosEnvios_IdMetodoEnvio",
                        column: x => x.IdMetodoEnvio,
                        principalTable: "MetodosEnvios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrdenesVenta_MetodosPagos_IdMetodoPago",
                        column: x => x.IdMetodoPago,
                        principalTable: "MetodosPagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrdenesVenta_tblUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "tblUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductosSubCategorias",
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
                    table.PrimaryKey("PK_ProductosSubCategorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosSubCategorias_tblProductos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "tblProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosSubCategorias_tblSubCategorias_IdSubCategoria",
                        column: x => x.IdSubCategoria,
                        principalTable: "tblSubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrdenesVentaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    EsActivo = table.Column<bool>(nullable: false),
                    FechaAlt = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    IdOrdenVenta = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrdenesVentaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrdenesVentaDetalle_tblOrdenesVenta_IdOrdenVenta",
                        column: x => x.IdOrdenVenta,
                        principalTable: "tblOrdenesVenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrdenesVentaDetalle_tblProductos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "tblProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "tblRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrdenesVenta_IdMetodoEnvio",
                table: "tblOrdenesVenta",
                column: "IdMetodoEnvio");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrdenesVenta_IdMetodoPago",
                table: "tblOrdenesVenta",
                column: "IdMetodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrdenesVenta_IdUser",
                table: "tblOrdenesVenta",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrdenesVentaDetalle_IdOrdenVenta",
                table: "tblOrdenesVentaDetalle",
                column: "IdOrdenVenta");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrdenesVentaDetalle_IdProducto",
                table: "tblOrdenesVentaDetalle",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosSubCategorias_IdProducto",
                table: "ProductosSubCategorias",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosSubCategorias_IdSubCategoria",
                table: "ProductosSubCategorias",
                column: "IdSubCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_tblSubCategorias_IdCategoria",
                table: "tblSubCategorias",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_tblRoleClaim_tblRole_RoleId",
                table: "tblRoleClaim",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserClaim_tblUser_UserId",
                table: "tblUserClaim",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserLogin_tblUser_UserId",
                table: "tblUserLogin",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRole_tblRole_RoleId",
                table: "tblUserRole",
                column: "RoleId",
                principalTable: "tblRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblUserRole_tblUser_UserId",
                table: "tblUserRole",
                column: "UserId",
                principalTable: "tblUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblRoleClaim_tblRole_RoleId",
                table: "tblRoleClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserClaim_tblUser_UserId",
                table: "tblUserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserLogin_tblUser_UserId",
                table: "tblUserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRole_tblRole_RoleId",
                table: "tblUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_tblUserRole_tblUser_UserId",
                table: "tblUserRole");

            migrationBuilder.DropTable(
                name: "tblOrdenesVentaDetalle");

            migrationBuilder.DropTable(
                name: "ProductosSubCategorias");

            migrationBuilder.DropTable(
                name: "tblOrdenesVenta");

            migrationBuilder.DropTable(
                name: "tblProductos");

            migrationBuilder.DropTable(
                name: "tblSubCategorias");

            migrationBuilder.DropTable(
                name: "MetodosEnvios");

            migrationBuilder.DropTable(
                name: "MetodosPagos");

            migrationBuilder.DropTable(
                name: "tblCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserToken",
                table: "tblUserToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserRole",
                table: "tblUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserLogin",
                table: "tblUserLogin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUserClaim",
                table: "tblUserClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRoleClaim",
                table: "tblRoleClaim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblRole",
                table: "tblRole");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "tblRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblUser",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "IdOrdenVenta",
                table: "tblUser");

            migrationBuilder.RenameTable(
                name: "tblUserToken",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "tblUserRole",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "tblUserLogin",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "tblUserClaim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "tblRoleClaim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "tblRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "tblUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserRole_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserLogin_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblUserClaim_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_tblRoleClaim_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
