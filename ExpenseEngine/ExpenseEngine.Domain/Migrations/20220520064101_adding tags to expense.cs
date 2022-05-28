using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class addingtagstoexpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Expenses");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseEntityId",
                table: "TagRules",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Expenses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TagRules_ExpenseEntityId",
                table: "TagRules",
                column: "ExpenseEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TagRules_Expenses_ExpenseEntityId",
                table: "TagRules",
                column: "ExpenseEntityId",
                principalTable: "Expenses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagRules_Expenses_ExpenseEntityId",
                table: "TagRules");

            migrationBuilder.DropIndex(
                name: "IX_TagRules_ExpenseEntityId",
                table: "TagRules");

            migrationBuilder.DropColumn(
                name: "ExpenseEntityId",
                table: "TagRules");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Expenses");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Expenses",
                type: "text",
                nullable: true);
        }
    }
}
