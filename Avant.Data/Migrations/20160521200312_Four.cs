using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Avant.Data.Migrations
{
    public partial class Four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ProductOrder_Product_ProductId", table: "ProductOrder");
            migrationBuilder.AddColumn<bool>(
                name: "Featured",
                table: "Product",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0m);
            migrationBuilder.AddColumn<bool>(
                name: "Promotional",
                table: "Product",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ProductOrder_Product_ProductId", table: "ProductOrder");
            migrationBuilder.DropColumn(name: "Featured", table: "Product");
            migrationBuilder.DropColumn(name: "Price", table: "Product");
            migrationBuilder.DropColumn(name: "Promotional", table: "Product");
            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Product_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
