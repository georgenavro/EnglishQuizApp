using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class newColumnTestCountInTestResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TestCount",
                table: "TestResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCount",
                table: "TestResults");
        }
    }
}
