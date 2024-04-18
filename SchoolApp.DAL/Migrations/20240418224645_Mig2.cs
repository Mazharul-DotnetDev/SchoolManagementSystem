using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NetSalary",
                table: "StaffSalary",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 1,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 2,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 3,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 4,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 5,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 6,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(9491));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 46, 40, 155, DateTimeKind.Local).AddTicks(9509));

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 1,
                column: "NetSalary",
                value: null);

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 2,
                column: "NetSalary",
                value: null);

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 3,
                column: "NetSalary",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetSalary",
                table: "StaffSalary");

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(720));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(722));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 1,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 2,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 3,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 4,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 5,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 6,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1252));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1712));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 4, 43, 23, 368, DateTimeKind.Local).AddTicks(1728));
        }
    }
}
