using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyCESI.Model.Migrations
{
    public partial class adddefaultdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: false,
                defaultValue: new DateTime(2020, 5, 28, 11, 2, 9, 937, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Subjects",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 5, 28, 11, 2, 9, 937, DateTimeKind.Local));
        }
    }
}
