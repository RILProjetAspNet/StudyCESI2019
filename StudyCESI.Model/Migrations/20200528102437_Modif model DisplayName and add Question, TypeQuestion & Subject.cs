using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class ModifmodelDisplayNameandaddQuestionTypeQuestionSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserExams",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "UserExamAnswers",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "TypeQuestions",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Subjects",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Questions",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "HoleAnswers",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Exams",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ExamQuestions",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "ChoiceAnswers",
                newName: "Date de création");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "BoolAnswers",
                newName: "Date de création");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "UserExamAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 749, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "TypeQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 744, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Questions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "HoleAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "Exams",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ExamQuestions",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "ChoiceAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date de création",
                table: "BoolAnswers",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local),
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "UserExams",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "UserExamAnswers",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "TypeQuestions",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "Subjects",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "Questions",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "HoleAnswers",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "Exams",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "ExamQuestions",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "ChoiceAnswers",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "Date de création",
                table: "BoolAnswers",
                newName: "CreationDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "UserExamAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 749, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TypeQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 744, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "HoleAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ExamQuestions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 748, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "ChoiceAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "BoolAnswers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 12, 24, 37, 747, DateTimeKind.Local));
        }
    }
}
