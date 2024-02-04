using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.AcademicYearId);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    attendanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PassingMarks = table.Column<int>(type: "int", nullable: false),
                    ExamStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                });

            migrationBuilder.CreateTable(
                name: "FeeTypes",
                columns: table => new
                {
                    FeetypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeTypeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeTypeStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypes", x => x.FeetypeId);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuardianEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.ParentId);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionDuration = table.Column<TimeSpan>(type: "time", nullable: false),
                    SessionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionID);
                });

            migrationBuilder.CreateTable(
                name: "AcademicMonths",
                columns: table => new
                {
                    AcademicMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademicMonthName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcademicYearId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicMonths", x => x.AcademicMonthId);
                    table.ForeignKey(
                        name: "FK_AcademicMonths_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearId");
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassStutus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassStutusDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: true),
                    SessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_classes_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                    table.ForeignKey(
                        name: "FK_classes_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID");
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subjects_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID");
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassesClassId = table.Column<int>(type: "int", nullable: true),
                    SessionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Sessions_SessionID",
                        column: x => x.SessionID,
                        principalTable: "Sessions",
                        principalColumn: "SessionID");
                    table.ForeignKey(
                        name: "FK_Sections_classes_ClassesClassId",
                        column: x => x.ClassesClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "ClassesSubject",
                columns: table => new
                {
                    refClassesClassId = table.Column<int>(type: "int", nullable: false),
                    refSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesSubject", x => new { x.refClassesClassId, x.refSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_ClassesSubject_Subjects_refSubjectsSubjectId",
                        column: x => x.refSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassesSubject_classes_refClassesClassId",
                        column: x => x.refClassesClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeDesignation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    refEmployeeTypeEmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Attendances_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "AttendanceId");
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_refEmployeeTypeEmployeeTypeId",
                        column: x => x.refEmployeeTypeEmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "ExamSubject",
                columns: table => new
                {
                    refExamsExamID = table.Column<int>(type: "int", nullable: false),
                    refSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSubject", x => new { x.refExamsExamID, x.refSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_ExamSubject_Exams_refExamsExamID",
                        column: x => x.refExamsExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSubject_Subjects_refSubjectsSubjectId",
                        column: x => x.refSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNumber = table.Column<int>(type: "int", nullable: false),
                    StudentDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false),
                    StudentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    ClassesClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "ParentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_classes_ClassesClassId",
                        column: x => x.ClassesClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceStudent",
                columns: table => new
                {
                    refAttendancesAttendanceId = table.Column<int>(type: "int", nullable: false),
                    refStudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStudent", x => new { x.refAttendancesAttendanceId, x.refStudentsStudentId });
                    table.ForeignKey(
                        name: "FK_AttendanceStudent_Attendances_refAttendancesAttendanceId",
                        column: x => x.refAttendancesAttendanceId,
                        principalTable: "Attendances",
                        principalColumn: "AttendanceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceStudent_Students_refStudentsStudentId",
                        column: x => x.refStudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: true),
                    AdmissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamSchedules",
                columns: table => new
                {
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamScheduleStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamScheduleEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    ObtainedMarks = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamScheduleStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamScheduleStatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    refExamExamID = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSchedules", x => x.ExamScheduleId);
                    table.ForeignKey(
                        name: "FK_ExamSchedules_Exams_refExamExamID",
                        column: x => x.refExamExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSchedules_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "FeePayments",
                columns: table => new
                {
                    FeePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ModeOfPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentModeDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    refStudentStudentId = table.Column<int>(type: "int", nullable: false),
                    AcademicMonthId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePayments", x => x.FeePaymentId);
                    table.ForeignKey(
                        name: "FK_FeePayments_AcademicMonths_AcademicMonthId",
                        column: x => x.AcademicMonthId,
                        principalTable: "AcademicMonths",
                        principalColumn: "AcademicMonthId");
                    table.ForeignKey(
                        name: "FK_FeePayments_Students_refStudentStudentId",
                        column: x => x.refStudentStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ClassesClassId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                    table.ForeignKey(
                        name: "FK_Resources_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                    table.ForeignKey(
                        name: "FK_Resources_classes_ClassesClassId",
                        column: x => x.ClassesClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    refStudentsStudentId = table.Column<int>(type: "int", nullable: false),
                    refSubjectsSubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.refStudentsStudentId, x.refSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_refStudentsStudentId",
                        column: x => x.refStudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects_refSubjectsSubjectId",
                        column: x => x.refSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    refAcademicYearAcademicYearId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.AdmissionId);
                    table.ForeignKey(
                        name: "FK_Admissions_AcademicYears_refAcademicYearAcademicYearId",
                        column: x => x.refAcademicYearAcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Enrollments_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollments",
                        principalColumn: "EnrollmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.NoAction,  // Disable cascading delete
            onUpdate: ReferentialAction.NoAction);  // Disable cascading update
                });

            // Here I made the changes, and It worked.
            //Previous: onDelete: ReferentialAction.Cascade);

            /*
 Problem:

Error Number:1785,State:0,Class:16
Introducing FOREIGN KEY constraint 'FK_Admissions_classes_refClassClassId' on table 'Admissions' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION, or modify other FOREIGN KEY constraints.
Could not create constraint or index. See previous errors.

Solution:

Due to potential cycles or multiple cascade paths, the original 'onDelete: ReferentialAction.Cascade'
has been replaced with 'onDelete: ReferentialAction.NoAction' in the foreign key constraints of the Admissions table.

Explanation:
When creating relationships, cascade actions could inadvertently create loops or conflicts, leading to migration errors.
By setting 'NoAction,' we prevent automatic cascading deletes or updates, requiring manual handling of related records.   
*/







            migrationBuilder.CreateTable(
                name: "FeeStructures",
                columns: table => new
                {
                    FeeStructureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeStructureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    refClassesClassId = table.Column<int>(type: "int", nullable: false),
                    refFeeTypeFeetypeId = table.Column<int>(type: "int", nullable: false),
                    FeePaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeStructures", x => x.FeeStructureId);
                    table.ForeignKey(
                        name: "FK_FeeStructures_FeePayments_FeePaymentId",
                        column: x => x.FeePaymentId,
                        principalTable: "FeePayments",
                        principalColumn: "FeePaymentId");
                    table.ForeignKey(
                        name: "FK_FeeStructures_FeeTypes_refFeeTypeFeetypeId",
                        column: x => x.refFeeTypeFeetypeId,
                        principalTable: "FeeTypes",
                        principalColumn: "FeetypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeeStructures_classes_refClassesClassId",
                        column: x => x.refClassesClassId,
                        principalTable: "classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicMonths_AcademicYearId",
                table: "AcademicMonths",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_EnrollmentId",
                table: "Admissions",
                column: "EnrollmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_refAcademicYearAcademicYearId",
                table: "Admissions",
                column: "refAcademicYearAcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_StudentId",
                table: "Admissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceStudent_refStudentsStudentId",
                table: "AttendanceStudent",
                column: "refStudentsStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_classes_ExamID",
                table: "classes",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_classes_SessionID",
                table: "classes",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassesSubject_refSubjectsSubjectId",
                table: "ClassesSubject",
                column: "refSubjectsSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AttendanceId",
                table: "Employees",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_refEmployeeTypeEmployeeTypeId",
                table: "Employees",
                column: "refEmployeeTypeEmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubjectId",
                table: "Employees",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassId",
                table: "Enrollments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedules_refExamExamID",
                table: "ExamSchedules",
                column: "refExamExamID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedules_StudentId",
                table: "ExamSchedules",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSubject_refSubjectsSubjectId",
                table: "ExamSubject",
                column: "refSubjectsSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FeePayments_AcademicMonthId",
                table: "FeePayments",
                column: "AcademicMonthId");

            migrationBuilder.CreateIndex(
                name: "IX_FeePayments_refStudentStudentId",
                table: "FeePayments",
                column: "refStudentStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeStructures_FeePaymentId",
                table: "FeeStructures",
                column: "FeePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeStructures_refClassesClassId",
                table: "FeeStructures",
                column: "refClassesClassId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeStructures_refFeeTypeFeetypeId",
                table: "FeeStructures",
                column: "refFeeTypeFeetypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ClassesClassId",
                table: "Resources",
                column: "ClassesClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_StudentId",
                table: "Resources",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ClassesClassId",
                table: "Sections",
                column: "ClassesClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SessionID",
                table: "Sections",
                column: "SessionID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassesClassId",
                table: "Students",
                column: "ClassesClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ParentId",
                table: "Students",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SectionId",
                table: "Students",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_refSubjectsSubjectId",
                table: "StudentSubject",
                column: "refSubjectsSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SessionID",
                table: "Subjects",
                column: "SessionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "AttendanceStudent");

            migrationBuilder.DropTable(
                name: "ClassesSubject");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ExamSchedules");

            migrationBuilder.DropTable(
                name: "ExamSubject");

            migrationBuilder.DropTable(
                name: "FeeStructures");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "FeePayments");

            migrationBuilder.DropTable(
                name: "FeeTypes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AcademicMonths");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
