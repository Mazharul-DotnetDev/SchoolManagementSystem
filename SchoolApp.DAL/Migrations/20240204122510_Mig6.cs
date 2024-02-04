using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_AcademicYears_refAcademicYearAcademicYearId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceStudent_Attendances_refAttendancesAttendanceId",
                table: "AttendanceStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceStudent_Students_refStudentsStudentId",
                table: "AttendanceStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSubject_Subjects_refSubjectsSubjectId",
                table: "ClassesSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSubject_classes_refClassesClassId",
                table: "ClassesSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_refEmployeeTypeEmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSchedules_Exams_refExamExamID",
                table: "ExamSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSubject_Exams_refExamsExamID",
                table: "ExamSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSubject_Subjects_refSubjectsSubjectId",
                table: "ExamSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_FeePayments_Students_refStudentStudentId",
                table: "FeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_FeeStructures_FeeTypes_refFeeTypeFeetypeId",
                table: "FeeStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_FeeStructures_classes_refClassesClassId",
                table: "FeeStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_refStudentsStudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_refSubjectsSubjectId",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Employees_refEmployeeTypeEmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "refEmployeeTypeEmployeeTypeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "refSubjectsSubjectId",
                table: "StudentSubject",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refStudentsStudentId",
                table: "StudentSubject",
                newName: "StudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_refSubjectsSubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refFeeTypeFeetypeId",
                table: "FeeStructures",
                newName: "FeetypeId");

            migrationBuilder.RenameColumn(
                name: "refClassesClassId",
                table: "FeeStructures",
                newName: "ClassesClassId");

            migrationBuilder.RenameIndex(
                name: "IX_FeeStructures_refFeeTypeFeetypeId",
                table: "FeeStructures",
                newName: "IX_FeeStructures_FeetypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FeeStructures_refClassesClassId",
                table: "FeeStructures",
                newName: "IX_FeeStructures_ClassesClassId");

            migrationBuilder.RenameColumn(
                name: "refStudentStudentId",
                table: "FeePayments",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_FeePayments_refStudentStudentId",
                table: "FeePayments",
                newName: "IX_FeePayments_StudentId");

            migrationBuilder.RenameColumn(
                name: "refSubjectsSubjectId",
                table: "ExamSubject",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refExamsExamID",
                table: "ExamSubject",
                newName: "ExamsExamID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSubject_refSubjectsSubjectId",
                table: "ExamSubject",
                newName: "IX_ExamSubject_SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refExamExamID",
                table: "ExamSchedules",
                newName: "ExamID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSchedules_refExamExamID",
                table: "ExamSchedules",
                newName: "IX_ExamSchedules_ExamID");

            migrationBuilder.RenameColumn(
                name: "refSubjectsSubjectId",
                table: "ClassesSubject",
                newName: "SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refClassesClassId",
                table: "ClassesSubject",
                newName: "ClassesClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesSubject_refSubjectsSubjectId",
                table: "ClassesSubject",
                newName: "IX_ClassesSubject_SubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "refStudentsStudentId",
                table: "AttendanceStudent",
                newName: "StudentsStudentId");

            migrationBuilder.RenameColumn(
                name: "refAttendancesAttendanceId",
                table: "AttendanceStudent",
                newName: "AttendancesAttendanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceStudent_refStudentsStudentId",
                table: "AttendanceStudent",
                newName: "IX_AttendanceStudent_StudentsStudentId");

            migrationBuilder.RenameColumn(
                name: "refAcademicYearAcademicYearId",
                table: "Admissions",
                newName: "AcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Admissions_refAcademicYearAcademicYearId",
                table: "Admissions",
                newName: "IX_Admissions_AcademicYearId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeTypeId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_AcademicYears_AcademicYearId",
                table: "Admissions",
                column: "AcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceStudent_Attendances_AttendancesAttendanceId",
                table: "AttendanceStudent",
                column: "AttendancesAttendanceId",
                principalTable: "Attendances",
                principalColumn: "AttendanceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceStudent_Students_StudentsStudentId",
                table: "AttendanceStudent",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSubject_Subjects_SubjectsSubjectId",
                table: "ClassesSubject",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSubject_classes_ClassesClassId",
                table: "ClassesSubject",
                column: "ClassesClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSchedules_Exams_ExamID",
                table: "ExamSchedules",
                column: "ExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSubject_Exams_ExamsExamID",
                table: "ExamSubject",
                column: "ExamsExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSubject_Subjects_SubjectsSubjectId",
                table: "ExamSubject",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeePayments_Students_StudentId",
                table: "FeePayments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeeStructures_FeeTypes_FeetypeId",
                table: "FeeStructures",
                column: "FeetypeId",
                principalTable: "FeeTypes",
                principalColumn: "FeetypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeeStructures_classes_ClassesClassId",
                table: "FeeStructures",
                column: "ClassesClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentsStudentId",
                table: "StudentSubject",
                column: "StudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsSubjectId",
                table: "StudentSubject",
                column: "SubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admissions_AcademicYears_AcademicYearId",
                table: "Admissions");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceStudent_Attendances_AttendancesAttendanceId",
                table: "AttendanceStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceStudent_Students_StudentsStudentId",
                table: "AttendanceStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSubject_Subjects_SubjectsSubjectId",
                table: "ClassesSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassesSubject_classes_ClassesClassId",
                table: "ClassesSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSchedules_Exams_ExamID",
                table: "ExamSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSubject_Exams_ExamsExamID",
                table: "ExamSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamSubject_Subjects_SubjectsSubjectId",
                table: "ExamSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_FeePayments_Students_StudentId",
                table: "FeePayments");

            migrationBuilder.DropForeignKey(
                name: "FK_FeeStructures_FeeTypes_FeetypeId",
                table: "FeeStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_FeeStructures_classes_ClassesClassId",
                table: "FeeStructures");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentsStudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectsSubjectId",
                table: "StudentSubject");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeTypeId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "StudentSubject",
                newName: "refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentId",
                table: "StudentSubject",
                newName: "refStudentsStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectsSubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "FeetypeId",
                table: "FeeStructures",
                newName: "refFeeTypeFeetypeId");

            migrationBuilder.RenameColumn(
                name: "ClassesClassId",
                table: "FeeStructures",
                newName: "refClassesClassId");

            migrationBuilder.RenameIndex(
                name: "IX_FeeStructures_FeetypeId",
                table: "FeeStructures",
                newName: "IX_FeeStructures_refFeeTypeFeetypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FeeStructures_ClassesClassId",
                table: "FeeStructures",
                newName: "IX_FeeStructures_refClassesClassId");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "FeePayments",
                newName: "refStudentStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_FeePayments_StudentId",
                table: "FeePayments",
                newName: "IX_FeePayments_refStudentStudentId");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "ExamSubject",
                newName: "refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "ExamsExamID",
                table: "ExamSubject",
                newName: "refExamsExamID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSubject_SubjectsSubjectId",
                table: "ExamSubject",
                newName: "IX_ExamSubject_refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "ExamSchedules",
                newName: "refExamExamID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamSchedules_ExamID",
                table: "ExamSchedules",
                newName: "IX_ExamSchedules_refExamExamID");

            migrationBuilder.RenameColumn(
                name: "SubjectsSubjectId",
                table: "ClassesSubject",
                newName: "refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "ClassesClassId",
                table: "ClassesSubject",
                newName: "refClassesClassId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassesSubject_SubjectsSubjectId",
                table: "ClassesSubject",
                newName: "IX_ClassesSubject_refSubjectsSubjectId");

            migrationBuilder.RenameColumn(
                name: "StudentsStudentId",
                table: "AttendanceStudent",
                newName: "refStudentsStudentId");

            migrationBuilder.RenameColumn(
                name: "AttendancesAttendanceId",
                table: "AttendanceStudent",
                newName: "refAttendancesAttendanceId");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceStudent_StudentsStudentId",
                table: "AttendanceStudent",
                newName: "IX_AttendanceStudent_refStudentsStudentId");

            migrationBuilder.RenameColumn(
                name: "AcademicYearId",
                table: "Admissions",
                newName: "refAcademicYearAcademicYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Admissions_AcademicYearId",
                table: "Admissions",
                newName: "IX_Admissions_refAcademicYearAcademicYearId");

            migrationBuilder.AddColumn<int>(
                name: "refEmployeeTypeEmployeeTypeId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_refEmployeeTypeEmployeeTypeId",
                table: "Employees",
                column: "refEmployeeTypeEmployeeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admissions_AcademicYears_refAcademicYearAcademicYearId",
                table: "Admissions",
                column: "refAcademicYearAcademicYearId",
                principalTable: "AcademicYears",
                principalColumn: "AcademicYearId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceStudent_Attendances_refAttendancesAttendanceId",
                table: "AttendanceStudent",
                column: "refAttendancesAttendanceId",
                principalTable: "Attendances",
                principalColumn: "AttendanceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceStudent_Students_refStudentsStudentId",
                table: "AttendanceStudent",
                column: "refStudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSubject_Subjects_refSubjectsSubjectId",
                table: "ClassesSubject",
                column: "refSubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassesSubject_classes_refClassesClassId",
                table: "ClassesSubject",
                column: "refClassesClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeTypes_refEmployeeTypeEmployeeTypeId",
                table: "Employees",
                column: "refEmployeeTypeEmployeeTypeId",
                principalTable: "EmployeeTypes",
                principalColumn: "EmployeeTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSchedules_Exams_refExamExamID",
                table: "ExamSchedules",
                column: "refExamExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSubject_Exams_refExamsExamID",
                table: "ExamSubject",
                column: "refExamsExamID",
                principalTable: "Exams",
                principalColumn: "ExamID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamSubject_Subjects_refSubjectsSubjectId",
                table: "ExamSubject",
                column: "refSubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeePayments_Students_refStudentStudentId",
                table: "FeePayments",
                column: "refStudentStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeeStructures_FeeTypes_refFeeTypeFeetypeId",
                table: "FeeStructures",
                column: "refFeeTypeFeetypeId",
                principalTable: "FeeTypes",
                principalColumn: "FeetypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeeStructures_classes_refClassesClassId",
                table: "FeeStructures",
                column: "refClassesClassId",
                principalTable: "classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_refStudentsStudentId",
                table: "StudentSubject",
                column: "refStudentsStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_refSubjectsSubjectId",
                table: "StudentSubject",
                column: "refSubjectsSubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
