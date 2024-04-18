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
            migrationBuilder.AddColumn<string>(
                name: "StaffName",
                table: "StaffSalary",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7030));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 1,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7534));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 2,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 3,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7552));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 4,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 5,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7558));

            migrationBuilder.UpdateData(
                table: "ExamSubject",
                keyColumn: "ExamSubjectId",
                keyValue: 6,
                column: "ExamDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 19, 19, 2, 38, 425, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "StaffName",
                value: "Jamir King");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "StaffName",
                value: "Jamir Jamidar");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "StaffName",
                value: "Jamir Amir");

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 1,
                column: "StaffName",
                value: "Jamir King");

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 2,
                column: "StaffName",
                value: "Jamir Jamidar");

            migrationBuilder.UpdateData(
                table: "StaffSalary",
                keyColumn: "StaffSalaryId",
                keyValue: 3,
                column: "StaffName",
                value: "Jamir Amir");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffName",
                table: "StaffSalary");

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
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "StaffName",
                value: "John Doe");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "StaffName",
                value: "Alice Smith");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 3,
                column: "StaffName",
                value: "John Doe");
        }
    }
}
