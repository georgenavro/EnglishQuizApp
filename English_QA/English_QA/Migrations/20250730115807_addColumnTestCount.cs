using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class addColumnTestCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestCount",
                table: "TestResults",
                newName: "TestResultCount");

            migrationBuilder.AddColumn<long>(
                name: "TestCount",
                table: "UserTest",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestCount",
                table: "UserTest");

            migrationBuilder.RenameColumn(
                name: "TestResultCount",
                table: "TestResults",
                newName: "TestCount");
        }
    }
}
