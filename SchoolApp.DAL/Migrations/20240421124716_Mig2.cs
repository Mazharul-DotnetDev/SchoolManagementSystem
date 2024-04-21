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
            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1517));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1518));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1519));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 21, 18, 47, 14, 493, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "ImagePath",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8794));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Attendance",
                keyColumn: "AttendanceId",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8795));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8924));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 20, 19, 7, 27, 238, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1,
                column: "ImagePath",
                value: "path/to/image.jpg");

            migrationBuilder.UpdateData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2,
                column: "ImagePath",
                value: "path/to/image.jpg");
        }
    }
}
