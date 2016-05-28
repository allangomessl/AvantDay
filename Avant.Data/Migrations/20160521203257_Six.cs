using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Avant.Data.Migrations
{
    public partial class Six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ProductOrder_Product_ProductId", table: "ProductOrder");
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Product",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Product",
                nullable: false,
                defaultValue: 0);
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
            migrationBuilder.DropColumn(name: "Photo", table: "Product");
            migrationBuilder.DropColumn(name: "Stock", table: "Product");
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
