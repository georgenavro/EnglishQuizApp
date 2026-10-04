using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace English_QA.Migrations
{
    public partial class variableChangedName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersType_UsersTypeID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UsersTypeID",
                table: "Users",
                newName: "UserTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UsersTypeID",
                table: "Users",
                newName: "IX_Users_UserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersType_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UsersType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UsersType_UserTypeID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTypeID",
                table: "Users",
                newName: "UsersTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                newName: "IX_Users_UsersTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UsersType_UsersTypeID",
                table: "Users",
                column: "UsersTypeID",
                principalTable: "UsersType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
