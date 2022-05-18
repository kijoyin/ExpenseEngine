using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class descriptionunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Description",
                table: "Expenses",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Expenses_Description",
                table: "Expenses");
        }
    }
}
