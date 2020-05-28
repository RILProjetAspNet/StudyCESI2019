using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class UpdateallCreationDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 462, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 2, 9, 937, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local),
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExamAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TypeQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 2, 9, 937, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 462, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HoleAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 466, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ExamQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChoiceAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BoolAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 8, 54, 465, DateTimeKind.Local));
        }
    }
}
