using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class addingtagstoexpense1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ExpenseEntityTagRuleEntity",
                columns: table => new
                {
                    ExpensesId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseEntityTagRuleEntity", x => new { x.ExpensesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ExpenseEntityTagRuleEntity_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseEntityTagRuleEntity_TagRules_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TagRules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseEntityTagRuleEntity_TagsId",
                table: "ExpenseEntityTagRuleEntity",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseEntityTagRuleEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "ExpenseEntityId",
                table: "TagRules",
                type: "uuid",
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
    }
}
