using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class UpdateModelandQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 749, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 542, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 744, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 749, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 744, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 542, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 546, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 37, 23, 545, DateTimeKind.Local));
        }
    }
}
