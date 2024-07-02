using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.Repository.DATA.Migrations
{
    public partial class AddRelationBetweenUserAndCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AppUserId",
                table: "Courses",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserId",
                table: "Courses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_AppUserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_AppUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses",
                column: "TrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Trainers_TrainerId",
                table: "Courses",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
