using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class NewColumnForTestResultsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TestPerAttempt",
                table: "TestResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestPerAttempt",
                table: "TestResults");
        }
    }
}
