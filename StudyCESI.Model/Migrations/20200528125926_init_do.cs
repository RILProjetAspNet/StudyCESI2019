using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class init_do : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 87, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 87, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 79, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 579, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 584, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 584, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 87, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 87, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 579, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 79, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 586, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 86, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 585, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 584, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 14, 55, 27, 584, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 14, 59, 26, 85, DateTimeKind.Local));
        }
    }
}
