using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class ChangeUserIdToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_UserId1",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_UserId1",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_UserId1",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Exams_UserId1",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserExams");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Exams");

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsers_Id",
                table: "UserExams",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 785, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 775, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsers_Id",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "AspNetUsers_Id",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_AspNetUsers_Id",
                table: "UserExams",
                column: "AspNetUsers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AspNetUsers_Id",
                table: "Questions",
                column: "AspNetUsers_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_AspNetUsers_Id",
                table: "Exams",
                column: "AspNetUsers_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_AspNetUsers_Id",
                table: "Exams",
                column: "AspNetUsers_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_AspNetUsers_Id",
                table: "Questions",
                column: "AspNetUsers_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_AspNetUsers_AspNetUsers_Id",
                table: "UserExams",
                column: "AspNetUsers_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_AspNetUsers_AspNetUsers_Id",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_AspNetUsers_Id",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_AspNetUsers_AspNetUsers_Id",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_UserExams_AspNetUsers_Id",
                table: "UserExams");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AspNetUsers_Id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Exams_AspNetUsers_Id",
                table: "Exams");

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "UserExams",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserExams",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExamAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 785, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TypeQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 775, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HoleAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local));

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Exams",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ExamQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 784, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChoiceAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BoolAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 30, 6, 783, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_UserExams_UserId1",
                table: "UserExams",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserId1",
                table: "Questions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_UserId1",
                table: "Exams",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_AspNetUsers_UserId1",
                table: "Exams",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_UserId1",
                table: "Questions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_AspNetUsers_UserId1",
                table: "UserExams",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
