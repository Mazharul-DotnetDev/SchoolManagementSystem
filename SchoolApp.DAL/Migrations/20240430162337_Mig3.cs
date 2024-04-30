using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalMarks",
                table: "MarkEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PassMarks",
                table: "MarkEntry",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(750));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(756));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(761));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1170));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1186));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1201));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1214));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 22, 23, 32, 735, DateTimeKind.Local).AddTicks(1258));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TotalMarks",
                table: "MarkEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassMarks",
                table: "MarkEntry",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3339));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3347));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3353));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3356));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3359));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3365));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 17, 4, 27, 658, DateTimeKind.Local).AddTicks(3374));
        }
    }
}
