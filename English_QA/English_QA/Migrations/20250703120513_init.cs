using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerTypes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "UsersType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false),
                    areaOfQuestionID = table.Column<long>(type: "INTEGER", nullable: false),
                    AnswerTypeID = table.Column<long>(type: "INTEGER", nullable: false),
                    MultipleAnswer01 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer02 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer03 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer04 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QA_AnswerTypes_AnswerTypeID",
                        column: x => x.AnswerTypeID,
                        principalTable: "AnswerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QA_areaOfQuestion_areaOfQuestionID",
                        column: x => x.areaOfQuestionID,
                        principalTable: "areaOfQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    UsersTypeID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UsersType_UsersTypeID",
                        column: x => x.UsersTypeID,
                        principalTable: "UsersType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer01 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer02 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer03 = table.Column<string>(type: "TEXT", nullable: false),
                    MultipleAnswer04 = table.Column<string>(type: "TEXT", nullable: false),
                    UserID = table.Column<long>(type: "INTEGER", nullable: false),
                    AreaOfQuestionID = table.Column<long>(type: "INTEGER", nullable: false),
                    AnswerTypeID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTest_AnswerTypes_AnswerTypeID",
                        column: x => x.AnswerTypeID,
                        principalTable: "AnswerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_areaOfQuestion_AreaOfQuestionID",
                        column: x => x.AreaOfQuestionID,
                        principalTable: "areaOfQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTest_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestResults",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserAnswer = table.Column<string>(type: "TEXT", nullable: false),
                    UserMultipleAnswer = table.Column<string>(type: "TEXT", nullable: false),
                    CorrectAnswers = table.Column<long>(type: "INTEGER", nullable: false),
                    CountQuestions = table.Column<long>(type: "INTEGER", nullable: false),
                    Results = table.Column<float>(type: "REAL", nullable: false),
                    UserTestID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResults_UserTest_UserTestID",
                        column: x => x.UserTestID,
                        principalTable: "UserTest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QA_AnswerTypeID",
                table: "QA",
                column: "AnswerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_QA_areaOfQuestionID",
                table: "QA",
                column: "areaOfQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_UserTestID",
                table: "TestResults",
                column: "UserTestID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UsersTypeID",
                table: "Users",
                column: "UsersTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_AnswerTypeID",
                table: "UserTest",
                column: "AnswerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_AreaOfQuestionID",
                table: "UserTest",
                column: "AreaOfQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserTest_UserID",
                table: "UserTest",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QA");

            migrationBuilder.DropTable(
                name: "TestResults");

            migrationBuilder.DropTable(
                name: "UserTest");

            migrationBuilder.DropTable(
                name: "AnswerTypes");

            migrationBuilder.DropTable(
                name: "areaOfQuestion");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersType");
        }
    }
}
