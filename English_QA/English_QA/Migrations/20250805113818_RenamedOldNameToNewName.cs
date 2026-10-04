using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class RenamedOldNameToNewName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QA_areaOfQuestion_areaOfQuestionID",
                table: "QA");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_areaOfQuestion_AreaOfQuestionID",
                table: "UserTest");

            migrationBuilder.DropTable(
                name: "areaOfQuestion");

            migrationBuilder.RenameColumn(
                name: "AreaOfQuestionID",
                table: "UserTest",
                newName: "questionCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_UserTest_AreaOfQuestionID",
                table: "UserTest",
                newName: "IX_UserTest_questionCategoryID");

            migrationBuilder.RenameColumn(
                name: "areaOfQuestionID",
                table: "QA",
                newName: "questionCategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_QA_areaOfQuestionID",
                table: "QA",
                newName: "IX_QA_questionCategoryID");

            migrationBuilder.CreateTable(
                name: "QuestionCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    questionCategory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionCategory", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QA_QuestionCategory_questionCategoryID",
                table: "QA",
                column: "questionCategoryID",
                principalTable: "QuestionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_QuestionCategory_questionCategoryID",
                table: "UserTest",
                column: "questionCategoryID",
                principalTable: "QuestionCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QA_QuestionCategory_questionCategoryID",
                table: "QA");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTest_QuestionCategory_questionCategoryID",
                table: "UserTest");

            migrationBuilder.DropTable(
                name: "QuestionCategory");

            migrationBuilder.RenameColumn(
                name: "questionCategoryID",
                table: "UserTest",
                newName: "AreaOfQuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_UserTest_questionCategoryID",
                table: "UserTest",
                newName: "IX_UserTest_AreaOfQuestionID");

            migrationBuilder.RenameColumn(
                name: "questionCategoryID",
                table: "QA",
                newName: "areaOfQuestionID");

            migrationBuilder.RenameIndex(
                name: "IX_QA_questionCategoryID",
                table: "QA",
                newName: "IX_QA_areaOfQuestionID");

            migrationBuilder.CreateTable(
                name: "areaOfQuestion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaOfQuestion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_areaOfQuestion", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QA_areaOfQuestion_areaOfQuestionID",
                table: "QA",
                column: "areaOfQuestionID",
                principalTable: "areaOfQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTest_areaOfQuestion_AreaOfQuestionID",
                table: "UserTest",
                column: "AreaOfQuestionID",
                principalTable: "areaOfQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
