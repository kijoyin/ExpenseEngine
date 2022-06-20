using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class addingbank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "Expenses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_BankId",
                table: "Expenses",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Banks_BankId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_BankId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "BankId",
                table: "Expenses");
        }
    }
}
