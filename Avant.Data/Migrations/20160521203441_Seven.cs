using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Avant.Data.Migrations
{
    public partial class Seven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ProductOrder_Product_ProductId", table: "ProductOrder");
            migrationBuilder.DropColumn(name: "Promotional", table: "Product");
            migrationBuilder.AddColumn<bool>(
                name: "Promotion",
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
            migrationBuilder.DropColumn(name: "Promotion", table: "Product");
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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
