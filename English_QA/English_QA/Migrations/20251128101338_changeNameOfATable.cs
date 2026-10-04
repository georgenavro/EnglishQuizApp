using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class changeNameOfATable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersType_UserTypeID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UsersType");

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UserType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeID",
                table: "Users");

            migrationBuilder.DropTable(
                name: "UserType");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersType_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UsersType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
