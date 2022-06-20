using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class addingunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_Description",
                table: "Expenses");

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "Expenses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueKey",
                table: "Expenses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UniqueKey",
                table: "Expenses",
                column: "UniqueKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_UniqueKey",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "UniqueKey",
                table: "Expenses");

            migrationBuilder.AlterColumn<Guid>(
                name: "BankId",
                table: "Expenses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Description",
                table: "Expenses",
                column: "Description",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }
    }
}
