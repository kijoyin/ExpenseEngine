using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseEngine.Domain.Migrations
{
    public partial class seedingmatch1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_TagRules_TagRuleEntityId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.DropIndex(
                name: "IX_Match_TagRuleEntityId",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "TagRuleEntityId",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.AddColumn<Guid>(
                name: "TagRuleId",
                table: "Matches",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TagRuleId",
                table: "Matches",
                column: "TagRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_TagRules_TagRuleId",
                table: "Matches",
                column: "TagRuleId",
                principalTable: "TagRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_TagRules_TagRuleId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TagRuleId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TagRuleId",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.AddColumn<Guid>(
                name: "TagRuleEntityId",
                table: "Match",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Match_TagRuleEntityId",
                table: "Match",
                column: "TagRuleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_TagRules_TagRuleEntityId",
                table: "Match",
                column: "TagRuleEntityId",
                principalTable: "TagRules",
                principalColumn: "Id");
        }
    }
}
