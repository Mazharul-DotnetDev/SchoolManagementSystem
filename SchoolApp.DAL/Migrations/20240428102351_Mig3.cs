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
            migrationBuilder.AddColumn<int>(
                name: "MarkEntryMarkId",
                table: "Student",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MarkEntry",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    PassMarks = table.Column<int>(type: "int", nullable: false),
                    ObtainedScore = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    PassStatus = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkEntry", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_MarkEntry_ExamSchedule_ExamScheduleId",
                        column: x => x.ExamScheduleId,
                        principalTable: "ExamSchedule",
                        principalColumn: "ExamScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarkEntry_ExamType_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "ExamType",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarkEntry_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarkEntry_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 16, 23, 48, 994, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 16, 23, 48, 994, DateTimeKind.Local).AddTicks(6052));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 16, 23, 48, 994, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 3,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 4,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 5,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 6,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 7,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 8,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 9,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 10,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 11,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 12,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "StudentId",
                keyValue: 13,
                column: "MarkEntryMarkId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Student_MarkEntryMarkId",
                table: "Student",
                column: "MarkEntryMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkEntry_ExamScheduleId",
                table: "MarkEntry",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkEntry_ExamTypeId",
                table: "MarkEntry",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkEntry_StaffId",
                table: "MarkEntry",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkEntry_SubjectId",
                table: "MarkEntry",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_MarkEntry_MarkEntryMarkId",
                table: "Student",
                column: "MarkEntryMarkId",
                principalTable: "MarkEntry",
                principalColumn: "MarkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_MarkEntry_MarkEntryMarkId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "MarkEntry");

            migrationBuilder.DropIndex(
                name: "IX_Student_MarkEntryMarkId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MarkEntryMarkId",
                table: "Student");

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 1,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5978));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 2,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5987));

            migrationBuilder.UpdateData(
                table: "Mark",
                keyColumn: "MarkId",
                keyValue: 3,
                column: "MarkEntryDate",
                value: new DateTime(2024, 4, 28, 1, 49, 7, 641, DateTimeKind.Local).AddTicks(5992));
        }
    }
}
