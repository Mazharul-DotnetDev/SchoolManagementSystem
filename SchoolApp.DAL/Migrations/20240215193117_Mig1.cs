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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbsAttendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresent = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsAttendance", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "dbsClassRoom",
                columns: table => new
                {
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassRoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassRoomCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsClassRoom", x => x.ClassRoomId);
                });

            migrationBuilder.CreateTable(
                name: "dbsDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<int>(type: "int", nullable: false),
                    NumberOfStaff = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsDepartment", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "dbsExamType",
                columns: table => new
                {
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTypeName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsExamType", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "dbsStaffSalary",
                columns: table => new
                {
                    StaffSalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FestivalBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HousingAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransportationAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavingFund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsStaffSalary", x => x.StaffSalaryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.UserId, x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsStudent",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionNo = table.Column<int>(type: "int", nullable: false),
                    EnrollmentNo = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentCurrentAge = table.Column<int>(type: "int", nullable: false),
                    StudentGender = table.Column<int>(type: "int", nullable: false),
                    StudentReligion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentNIDNumber = table.Column<int>(type: "int", nullable: false),
                    StudentContactNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentContactNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentEamil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherNID = table.Column<int>(type: "int", nullable: false),
                    FatherContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherNID = table.Column<int>(type: "int", nullable: false),
                    MotherContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalGuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsStudent", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_dbsStudent_dbsAttendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "dbsAttendance",
                        principalColumn: "AttendanceId");
                    table.ForeignKey(
                        name: "FK_dbsStudent_dbsClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "dbsClassRoom",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsSubject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectCode = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsSubject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_dbsSubject_dbsClassRoom_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "dbsClassRoom",
                        principalColumn: "ClassRoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsExamSchedule",
                columns: table => new
                {
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsExamSchedule", x => x.ExamScheduleId);
                    table.ForeignKey(
                        name: "FK_dbsExamSchedule_dbsExamType_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "dbsExamType",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsStaff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Designation = table.Column<int>(type: "int", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StaffSalaryId = table.Column<int>(type: "int", nullable: false),
                    AttendanceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsStaff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_dbsStaff_dbsAttendance_AttendanceId",
                        column: x => x.AttendanceId,
                        principalTable: "dbsAttendance",
                        principalColumn: "AttendanceId");
                    table.ForeignKey(
                        name: "FK_dbsStaff_dbsDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "dbsDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbsStaff_dbsStaffSalary_StaffSalaryId",
                        column: x => x.StaffSalaryId,
                        principalTable: "dbsStaffSalary",
                        principalColumn: "StaffSalaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsExamSubject",
                columns: table => new
                {
                    ExamSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ExamScheduleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsExamSubject", x => x.ExamSubjectId);
                    table.ForeignKey(
                        name: "FK_dbsExamSubject_dbsExamSchedule_ExamScheduleId",
                        column: x => x.ExamScheduleId,
                        principalTable: "dbsExamSchedule",
                        principalColumn: "ExamScheduleId");
                    table.ForeignKey(
                        name: "FK_dbsExamSubject_dbsSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbsSubject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsMarkEntry",
                columns: table => new
                {
                    MarkEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkEntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsMarkEntry", x => x.MarkEntryId);
                    table.ForeignKey(
                        name: "FK_dbsMarkEntry_dbsStaff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "dbsStaff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbsMarkEntry_dbsSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbsSubject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dbsStaffExperience",
                columns: table => new
                {
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Achievements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsStaffExperience", x => x.StaffExperienceId);
                    table.ForeignKey(
                        name: "FK_dbsStaffExperience_dbsStaff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "dbsStaff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "dbsMark",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamPaperScore = table.Column<int>(type: "int", nullable: false),
                    PassMarks = table.Column<int>(type: "int", nullable: false),
                    ObtainedScore = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    PassStatus = table.Column<int>(type: "int", nullable: false),
                    MarkEntryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    MarkEntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbsMark", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_dbsMark_dbsMarkEntry_MarkEntryId",
                        column: x => x.MarkEntryId,
                        principalTable: "dbsMarkEntry",
                        principalColumn: "MarkEntryId");
                    table.ForeignKey(
                        name: "FK_dbsMark_dbsStudent_StudentId",
                        column: x => x.StudentId,
                        principalTable: "dbsStudent",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbsMark_dbsSubject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "dbsSubject",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_dbsExamSchedule_ExamTypeId",
                table: "dbsExamSchedule",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsExamSubject_ExamScheduleId",
                table: "dbsExamSubject",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsExamSubject_SubjectId",
                table: "dbsExamSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsMark_MarkEntryId",
                table: "dbsMark",
                column: "MarkEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsMark_StudentId",
                table: "dbsMark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsMark_SubjectId",
                table: "dbsMark",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsMarkEntry_StaffId",
                table: "dbsMarkEntry",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsMarkEntry_SubjectId",
                table: "dbsMarkEntry",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStaff_AttendanceId",
                table: "dbsStaff",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStaff_DepartmentId",
                table: "dbsStaff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStaff_StaffSalaryId",
                table: "dbsStaff",
                column: "StaffSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStaffExperience_StaffId",
                table: "dbsStaffExperience",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStudent_AttendanceId",
                table: "dbsStudent",
                column: "AttendanceId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsStudent_ClassRoomId",
                table: "dbsStudent",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_dbsSubject_ClassRoomId",
                table: "dbsSubject",
                column: "ClassRoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "dbsExamSubject");

            migrationBuilder.DropTable(
                name: "dbsMark");

            migrationBuilder.DropTable(
                name: "dbsStaffExperience");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "dbsExamSchedule");

            migrationBuilder.DropTable(
                name: "dbsMarkEntry");

            migrationBuilder.DropTable(
                name: "dbsStudent");

            migrationBuilder.DropTable(
                name: "dbsExamType");

            migrationBuilder.DropTable(
                name: "dbsStaff");

            migrationBuilder.DropTable(
                name: "dbsSubject");

            migrationBuilder.DropTable(
                name: "dbsAttendance");

            migrationBuilder.DropTable(
                name: "dbsDepartment");

            migrationBuilder.DropTable(
                name: "dbsStaffSalary");

            migrationBuilder.DropTable(
                name: "dbsClassRoom");
        }
    }
}
