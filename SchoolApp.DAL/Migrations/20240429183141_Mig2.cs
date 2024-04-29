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
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Standard_StandardId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AdmissionNo",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_EnrollmentNo",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "StandardId",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EnrollmentNo",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdmissionNo",
                table: "Student",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(3512));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(3519));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 4,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(5428));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4210));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4234));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4245));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4254));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4264));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4275));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "StudentDOB",
                value: new DateTime(2024, 4, 30, 0, 31, 37, 147, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Standard_StandardId",
                table: "Student",
                column: "StandardId",
                principalTable: "Standard",
                principalColumn: "StandardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Standard_StandardId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "StandardId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnrollmentNo",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdmissionNo",
                table: "Student",
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
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(8586));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(9608));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(9625));

            migrationBuilder.UpdateData(
                table: "MarkEntry",
                keyColumn: "MarkEntryId",
                keyValue: 4,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 29, 0, 13, 59, 991, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "StudentDOB",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdmissionNo",
                table: "Student",
                column: "AdmissionNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Student_EnrollmentNo",
                table: "Student",
                column: "EnrollmentNo",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Standard_StandardId",
                table: "Student",
                column: "StandardId",
                principalTable: "Standard",
                principalColumn: "StandardId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
