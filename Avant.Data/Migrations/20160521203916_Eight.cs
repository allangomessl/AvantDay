using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Avant.Data.Migrations
{
    public partial class Eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_ProductOrder_Product_ProductId", table: "ProductOrder");
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ProductOrder",
                nullable: false);
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
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "ProductOrder",
                nullable: false);
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
