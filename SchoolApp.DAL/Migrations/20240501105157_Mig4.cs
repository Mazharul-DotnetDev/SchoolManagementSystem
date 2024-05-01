using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(3543));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(3561));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4236));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4256));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "StudentDOB",
                value: new DateTime(2024, 5, 1, 16, 51, 51, 337, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 4,
                column: "SubjectCode",
                value: 201);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 5,
                column: "SubjectCode",
                value: 202);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 6,
                column: "SubjectCode",
                value: 203);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 7,
                column: "SubjectCode",
                value: 301);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 8,
                column: "SubjectCode",
                value: 302);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 9,
                column: "SubjectCode",
                value: 303);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 10,
                column: "SubjectCode",
                value: 401);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 11,
                column: "SubjectCode",
                value: 402);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 12,
                column: "SubjectCode",
                value: 403);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 4,
                column: "SubjectCode",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 5,
                column: "SubjectCode",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 6,
                column: "SubjectCode",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 7,
                column: "SubjectCode",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 8,
                column: "SubjectCode",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 9,
                column: "SubjectCode",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 10,
                column: "SubjectCode",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 11,
                column: "SubjectCode",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Subject",
                keyColumn: "SubjectId",
                keyValue: 12,
                column: "SubjectCode",
                value: 112);
        }
    }
}
