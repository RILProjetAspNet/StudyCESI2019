using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class ChangeNotNullableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoolAnswers_Questions_Question_QuestionId",
                table: "BoolAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceAnswers_Questions_Question_QuestionId",
                table: "ChoiceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_Question_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_HoleAnswers_Questions_Question_QuestionId",
                table: "HoleAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_Subject_SubjectId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExamAnswers_Questions_Question_QuestionId",
                table: "UserExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_Exam_ExamId",
                table: "UserExams");

            migrationBuilder.AlterColumn<int>(
                name: "Exam_ExamId",
                table: "UserExams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "UserExamAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Subject_SubjectId",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "HoleAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "ExamQuestions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "ChoiceAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "BoolAnswers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoolAnswers_Questions_Question_QuestionId",
                table: "BoolAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceAnswers_Questions_Question_QuestionId",
                table: "ChoiceAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_Question_QuestionId",
                table: "ExamQuestions",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoleAnswers_Questions_Question_QuestionId",
                table: "HoleAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_Subject_SubjectId",
                table: "Questions",
                column: "Subject_SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamAnswers_Questions_Question_QuestionId",
                table: "UserExamAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_Exam_ExamId",
                table: "UserExams",
                column: "Exam_ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoolAnswers_Questions_Question_QuestionId",
                table: "BoolAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ChoiceAnswers_Questions_Question_QuestionId",
                table: "ChoiceAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Questions_Question_QuestionId",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_HoleAnswers_Questions_Question_QuestionId",
                table: "HoleAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Subjects_Subject_SubjectId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExamAnswers_Questions_Question_QuestionId",
                table: "UserExamAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExams_Exams_Exam_ExamId",
                table: "UserExams");

            migrationBuilder.AlterColumn<int>(
                name: "Exam_ExamId",
                table: "UserExams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "UserExamAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Subject_SubjectId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "HoleAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AspNetUsers_Id",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "ExamQuestions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "ChoiceAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Question_QuestionId",
                table: "BoolAnswers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BoolAnswers_Questions_Question_QuestionId",
                table: "BoolAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChoiceAnswers_Questions_Question_QuestionId",
                table: "ChoiceAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Questions_Question_QuestionId",
                table: "ExamQuestions",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoleAnswers_Questions_Question_QuestionId",
                table: "HoleAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Subjects_Subject_SubjectId",
                table: "Questions",
                column: "Subject_SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExamAnswers_Questions_Question_QuestionId",
                table: "UserExamAnswers",
                column: "Question_QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExams_Exams_Exam_ExamId",
                table: "UserExams",
                column: "Exam_ExamId",
                principalTable: "Exams",
                principalColumn: "ExamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
