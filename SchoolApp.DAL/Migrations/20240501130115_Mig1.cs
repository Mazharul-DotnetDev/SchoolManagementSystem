using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYear",
                columns: table => new
                {
                    AcademicYearId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYear", x => x.AcademicYearId);
                });

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
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AttendanceIdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ExamSchedule",
                columns: table => new
                {
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSchedule", x => x.ExamScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "ExamType",
                columns: table => new
                {
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamType", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FeeType",
                columns: table => new
                {
                    FeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeType", x => x.FeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StaffSalary",
                columns: table => new
                {
                    StaffSalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FestivalBonus = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Allowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HousingAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportationAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SavingFund = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true, computedColumnSql: "([BasicSalary] + [FestivalBonus] + [Allowance] + [MedicalAllowance] + [HousingAllowance] + [TransportationAllowance] - [SavingFund] - [Taxes])")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffSalary", x => x.StaffSalaryId);
                });

            migrationBuilder.CreateTable(
                name: "Standard",
                columns: table => new
                {
                    StandardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standard", x => x.StandardId);
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
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniqueStaffAttendanceNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Designation = table.Column<int>(type: "int", nullable: true),
                    BankAccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    StaffSalaryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Staff_StaffSalary_StaffSalaryId",
                        column: x => x.StaffSalaryId,
                        principalTable: "StaffSalary",
                        principalColumn: "StaffSalaryId");
                });

            migrationBuilder.CreateTable(
                name: "ExamScheduleStandard",
                columns: table => new
                {
                    ExamScheduleStandardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamScheduleId = table.Column<int>(type: "int", nullable: true),
                    StandardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamScheduleStandard", x => x.ExamScheduleStandardId);
                    table.ForeignKey(
                        name: "FK_ExamScheduleStandard_ExamSchedule_ExamScheduleId",
                        column: x => x.ExamScheduleId,
                        principalTable: "ExamSchedule",
                        principalColumn: "ExamScheduleId");
                    table.ForeignKey(
                        name: "FK_ExamScheduleStandard_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdmissionNo = table.Column<int>(type: "int", nullable: true),
                    EnrollmentNo = table.Column<int>(type: "int", nullable: true),
                    UniqueStudentAttendanceNumber = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentGender = table.Column<int>(type: "int", nullable: true),
                    StudentReligion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentBloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentNIDNumber = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    StudentContactNumber1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentContactNumber2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherNID = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    FatherContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherNID = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: true),
                    MotherContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalGuardianContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
                        principalColumn: "StandardId");
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectCode = table.Column<int>(type: "int", nullable: true),
                    StandardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                    table.ForeignKey(
                        name: "FK_Subject_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
                        principalColumn: "StandardId");
                });

            migrationBuilder.CreateTable(
                name: "StaffExperience",
                columns: table => new
                {
                    StaffExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Achievements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffExperience", x => x.StaffExperienceId);
                    table.ForeignKey(
                        name: "FK_StaffExperience_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId");
                });

            migrationBuilder.CreateTable(
                name: "MonthlyPayment",
                columns: table => new
                {
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TotalFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Waver = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreviousDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountRemaining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyPayment", x => x.MonthlyPaymentId);
                    table.ForeignKey(
                        name: "FK_MonthlyPayment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "OthersPayment",
                columns: table => new
                {
                    OthersPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountRemaining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OthersPayment", x => x.OthersPaymentId);
                    table.ForeignKey(
                        name: "FK_OthersPayment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "ExamSubject",
                columns: table => new
                {
                    ExamSubjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamScheduleStandardId = table.Column<int>(type: "int", nullable: true),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExamStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExamEndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSubject", x => x.ExamSubjectId);
                    table.ForeignKey(
                        name: "FK_ExamSubject_ExamScheduleStandard_ExamScheduleStandardId",
                        column: x => x.ExamScheduleStandardId,
                        principalTable: "ExamScheduleStandard",
                        principalColumn: "ExamScheduleStandardId");
                    table.ForeignKey(
                        name: "FK_ExamSubject_ExamType_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "ExamType",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    MarkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    PassMarks = table.Column<int>(type: "int", nullable: false),
                    ObtainedScore = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    PassStatus = table.Column<int>(type: "int", nullable: false),
                    MarkEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.MarkId);
                    table.ForeignKey(
                        name: "FK_Mark_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mark_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId");
                });

            migrationBuilder.CreateTable(
                name: "MarkEntry",
                columns: table => new
                {
                    MarkEntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: true),
                    PassMarks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkEntry", x => x.MarkEntryId);
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
                        name: "FK_MarkEntry_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarkEntry_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicMonth",
                columns: table => new
                {
                    MonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicMonth", x => x.MonthId);
                    table.ForeignKey(
                        name: "FK_AcademicMonth_MonthlyPayment_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayment",
                        principalColumn: "MonthlyPaymentId");
                });

            migrationBuilder.CreateTable(
                name: "DueBalance",
                columns: table => new
                {
                    DueBalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    DueBalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DueBalance", x => x.DueBalanceId);
                    table.ForeignKey(
                        name: "FK_DueBalance_MonthlyPayment_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayment",
                        principalColumn: "MonthlyPaymentId");
                    table.ForeignKey(
                        name: "FK_DueBalance_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: false),
                    FeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.PaymentDetailId);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_MonthlyPayment_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayment",
                        principalColumn: "MonthlyPaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMonth",
                columns: table => new
                {
                    PaymentMonthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMonth", x => x.PaymentMonthId);
                    table.ForeignKey(
                        name: "FK_PaymentMonth_MonthlyPayment_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayment",
                        principalColumn: "MonthlyPaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    FeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeTypeId = table.Column<int>(type: "int", nullable: false),
                    StandardId = table.Column<int>(type: "int", nullable: false),
                    PaymentFrequency = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyPaymentId = table.Column<int>(type: "int", nullable: true),
                    OthersPaymentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.FeeId);
                    table.ForeignKey(
                        name: "FK_Fee_FeeType_FeeTypeId",
                        column: x => x.FeeTypeId,
                        principalTable: "FeeType",
                        principalColumn: "FeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fee_MonthlyPayment_MonthlyPaymentId",
                        column: x => x.MonthlyPaymentId,
                        principalTable: "MonthlyPayment",
                        principalColumn: "MonthlyPaymentId");
                    table.ForeignKey(
                        name: "FK_Fee_OthersPayment_OthersPaymentId",
                        column: x => x.OthersPaymentId,
                        principalTable: "OthersPayment",
                        principalColumn: "OthersPaymentId");
                    table.ForeignKey(
                        name: "FK_Fee_Standard_StandardId",
                        column: x => x.StandardId,
                        principalTable: "Standard",
                        principalColumn: "StandardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherPaymentDetail",
                columns: table => new
                {
                    PaymentDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OthersPaymentId = table.Column<int>(type: "int", nullable: false),
                    FeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPaymentDetail", x => x.PaymentDetailId);
                    table.ForeignKey(
                        name: "FK_OtherPaymentDetail_OthersPayment_OthersPaymentId",
                        column: x => x.OthersPaymentId,
                        principalTable: "OthersPayment",
                        principalColumn: "OthersPaymentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMarksDetails",
                columns: table => new
                {
                    MarkEntryId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObtainedScore = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    PassStatus = table.Column<int>(type: "int", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMarksDetails", x => new { x.StudentId, x.MarkEntryId });
                    table.ForeignKey(
                        name: "FK_StudentMarksDetails_MarkEntry_MarkEntryId",
                        column: x => x.MarkEntryId,
                        principalTable: "MarkEntry",
                        principalColumn: "MarkEntryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMarksDetails_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicMonth",
                columns: new[] { "MonthId", "MonthName", "MonthlyPaymentId" },
                values: new object[,]
                {
                    { 1, "January", null },
                    { 2, "February", null },
                    { 3, "March", null },
                    { 4, "April", null },
                    { 5, "May", null },
                    { 6, "June", null },
                    { 7, "July", null },
                    { 8, "August", null },
                    { 9, "September", null },
                    { 10, "October", null },
                    { 11, "November", null },
                    { 12, "December", null }
                });

            migrationBuilder.InsertData(
                table: "AcademicYear",
                columns: new[] { "AcademicYearId", "Name" },
                values: new object[,]
                {
                    { 1, "2000" },
                    { 2, "2001" },
                    { 3, "2002" },
                    { 4, "2003" },
                    { 5, "2004" },
                    { 6, "2005" },
                    { 7, "2006" },
                    { 8, "2007" },
                    { 9, "2008" },
                    { 10, "2009" },
                    { 11, "2010" },
                    { 12, "2011" },
                    { 13, "2012" },
                    { 14, "2013" },
                    { 15, "2014" },
                    { 16, "2015" },
                    { 17, "2016" },
                    { 18, "2017" },
                    { 19, "2018" },
                    { 20, "2019" },
                    { 21, "2020" },
                    { 22, "2021" },
                    { 23, "2022" },
                    { 24, "2023" },
                    { 25, "2024" },
                    { 26, "2025" },
                    { 27, "2026" },
                    { 28, "2027" },
                    { 29, "2028" },
                    { 30, "2029" },
                    { 31, "2030" },
                    { 32, "2031" },
                    { 33, "2032" },
                    { 34, "2033" },
                    { 35, "2034" },
                    { 36, "2035" },
                    { 37, "2036" },
                    { 38, "2037" },
                    { 39, "2038" },
                    { 40, "2039" },
                    { 41, "2040" },
                    { 42, "2041" },
                    { 43, "2042" },
                    { 44, "2043" },
                    { 45, "2044" },
                    { 46, "2045" },
                    { 47, "2046" },
                    { 48, "2047" },
                    { 49, "2048" },
                    { 50, "2049" },
                    { 51, "2050" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Teacher" },
                    { 2, "Account" },
                    { 3, "Administration" },
                    { 4, "Student Affairs" },
                    { 5, "Counseling" },
                    { 6, "Sports" },
                    { 7, "Library" },
                    { 8, "Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "ExamSchedule",
                columns: new[] { "ExamScheduleId", "ExamScheduleName" },
                values: new object[,]
                {
                    { 1, "First Semester" },
                    { 2, "Second Semester" },
                    { 3, "Third Semester" }
                });

            migrationBuilder.InsertData(
                table: "ExamType",
                columns: new[] { "ExamTypeId", "ExamTypeName" },
                values: new object[,]
                {
                    { 1, "Midterm" },
                    { 2, "Final" },
                    { 3, "Practical" },
                    { 4, "Monthly Exam" },
                    { 5, "Lab Exam" }
                });

            migrationBuilder.InsertData(
                table: "FeeType",
                columns: new[] { "FeeTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Registration Fee" },
                    { 2, "Tuition Fee" },
                    { 3, "Library Fee" },
                    { 4, "Examination Fee" },
                    { 5, "Sports Fee" },
                    { 6, "Transportation Fee" }
                });

            migrationBuilder.InsertData(
                table: "StaffExperience",
                columns: new[] { "StaffExperienceId", "Achievements", "CompanyName", "Designation", "JoiningDate", "LeavingDate", "Responsibilities", "StaffId" },
                values: new object[,]
                {
                    { 1, "Received Employee of the Month award.", "ABC Company", "Software Engineer", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developed web applications.", null },
                    { 2, "Implemented a new data visualization system.", "XYZ Corporation", "Data Analyst", new DateTime(2018, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analyzed data to provide insights.", null },
                    { 3, "Successfully delivered multiple projects on time.", "EFG Ltd.", "Project Manager", new DateTime(2016, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Led a team of developers.", null }
                });

            migrationBuilder.InsertData(
                table: "StaffSalary",
                columns: new[] { "StaffSalaryId", "Allowance", "BasicSalary", "FestivalBonus", "HousingAllowance", "MedicalAllowance", "SavingFund", "StaffName", "Taxes", "TransportationAllowance" },
                values: new object[,]
                {
                    { 1, 500m, 5000m, 1000m, 800m, 300m, 200m, "Jamir King", 500m, 200m },
                    { 2, 500m, 5000m, 1000m, 800m, 300m, 200m, "Jamir Jamidar", 500m, 200m },
                    { 3, 500m, 5000m, 1000m, 800m, 300m, 200m, "Jamir Amir", 500m, 200m }
                });

            migrationBuilder.InsertData(
                table: "Standard",
                columns: new[] { "StandardId", "StandardCapacity", "StandardName" },
                values: new object[,]
                {
                    { 1, "30", "Class One" },
                    { 2, "35", "Class Two" },
                    { 3, "32", "Class Three" },
                    { 4, "28", "Class Four" },
                    { 5, "30", "Class Five" },
                    { 6, "30", "Class Six" },
                    { 7, "30", "Class Seven" },
                    { 8, "30", "Class Eight" },
                    { 9, "30", "Class Nine" },
                    { 10, "30", "Class Ten" }
                });

            migrationBuilder.InsertData(
                table: "Fee",
                columns: new[] { "FeeId", "Amount", "DueDate", "FeeTypeId", "MonthlyPaymentId", "OthersPaymentId", "PaymentFrequency", "StandardId" },
                values: new object[,]
                {
                    { 1, 1500m, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 1 },
                    { 2, 500m, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, 0, 1 },
                    { 3, 200m, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, 0, 1 },
                    { 4, 100m, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, null, 0, 1 },
                    { 5, 250m, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null, 5, 1 },
                    { 6, 300m, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null, 5, 1 },
                    { 7, 1500m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 2 },
                    { 8, 500m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, 0, 2 },
                    { 9, 200m, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, 0, 2 },
                    { 10, 100m, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, null, 0, 2 },
                    { 11, 250m, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null, 5, 2 },
                    { 12, 300m, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null, 5, 2 },
                    { 13, 1500m, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 3 },
                    { 14, 500m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, 0, 3 },
                    { 15, 200m, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, 0, 3 },
                    { 16, 100m, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, null, 0, 3 },
                    { 17, 250m, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, null, 5, 3 },
                    { 18, 300m, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null, 5, 3 },
                    { 19, 1500m, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, 1, 4 },
                    { 20, 500m, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, 0, 4 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "BankAccountName", "BankAccountNumber", "BankBranch", "BankName", "ContactNumber1", "DOB", "DepartmentId", "Designation", "Email", "FatherName", "Gender", "ImagePath", "JoiningDate", "MotherName", "PermanentAddress", "Qualifications", "StaffName", "StaffSalaryId", "Status", "TemporaryAddress", "UniqueStaffAttendanceNumber" },
                values: new object[,]
                {
                    { 1, "John Doe", 1234567890, "XYZ Branch", "ABC Bank", "1234567890", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 13, "john.doe@example.com", "Michael Doe", 0, null, new DateTime(2010, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Doe", "Permanent Address", "Bachelor's in Computer Science", "Jamir King", 1, "Active", "Temporary Address", 201 },
                    { 2, "Alice Smith", 9873210, "UVW Branch", "DEF Bank", "9876543210", new DateTime(1990, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, "alice.smith@example.com", "David Smith", 1, null, new DateTime(2015, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Smith", "Permanent Address", "Master's in Education", "Jamir Jamidar", 2, "Active", "Temporary Address", 202 },
                    { 3, "John Doe", 1234567890, "Main Street", "Anytown Bank", "555-123-4567", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, "john.doe@example.com", "Richard Doe", 0, null, new DateTime(2020, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Doe", "456 Elm Street, Anytown", "Bachelor of Science in Mathematics", "Jamir Amir", 3, "Active", "123 Main Street, Anytown", 203 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "AdmissionNo", "EnrollmentNo", "FatherContactNumber", "FatherNID", "FatherName", "ImagePath", "LocalGuardianContactNumber", "LocalGuardianName", "MotherContactNumber", "MotherNID", "MotherName", "PermanentAddress", "StandardId", "StudentBloodGroup", "StudentContactNumber1", "StudentContactNumber2", "StudentDOB", "StudentEmail", "StudentGender", "StudentNIDNumber", "StudentName", "StudentNationality", "StudentReligion", "TemporaryAddress", "UniqueStudentAttendanceNumber" },
                values: new object[,]
                {
                    { 1, 1000, 2000, "9876543210", "17948678987624322", "Michael Doe", null, "9876543230", "Jane Smith", "9876543220", "17948678987754322", "Alice Doe", "123 Main Street, City, Country", 1, "A+", "1234567890", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", 0, "12345678901234567", "John Doe", "Bangladeshi", null, "456 Elm Street, City, Country", 1000 },
                    { 2, 1001, 2001, "9876543220", "12345678901234567", "Abdul Rahman", null, "9876543240", "Kamal Ahmed", "9876543230", "12345678901234568", "Ayesha Rahman", "Dhaka, Bangladesh", 1, "B+", "9876543210", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatima.rahman@example.com", 1, "12345678901234567", "Fatima Rahman", "Bangladeshi", null, "Dhaka, Bangladesh", 1001 },
                    { 3, 1002, 2002, "9876543221", "98765432109876544", "Rahim Khan", null, "9876543241", "Kamal Ahmed", "9876543231", "98765432109876545", "Fatima Khan", "Chittagong, Bangladesh", 1, "O+", "9876543211", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "aryan.khan@example.com", 0, "98765432109876543", "Aryan Khan", "Bangladeshi", null, "Chittagong, Bangladesh", 1002 },
                    { 4, 1003, 2003, "9876543222", "76543210987654322", "Mahmud Ahmed", null, "9876543242", "Nadia Rahman", "9876543232", "76543210987654323", "Farida Ahmed", "Sylhet, Bangladesh", 2, "AB+", "9876543212", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tasnim.ahmed@example.com", 1, "76543210987654321", "Tasnim Ahmed", "Bangladeshi", null, "Sylhet, Bangladesh", 1003 },
                    { 5, 1004, 2004, "9876543223", "87654321098765433", "Nasir Khan", null, "9876543243", "Abdul Ali", "9876543233", "87654321098765434", "Sadia Khan", "Rajshahi, Bangladesh", 2, "A-", "9876543213", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "imran.khan@example.com", 0, "87654321098765432", "Imran Khan", "Bangladeshi", null, "Rajshahi, Bangladesh", 1004 },
                    { 6, 1005, 2005, "9876543224", "65432109876543211", "Hasan Rahman", null, "9876543244", "Khaled Islam", "9876543234", "65432109876543212", "Sabina Rahman", "Dhaka, Bangladesh", 2, "B-", "9876543214", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "anika.rahman@example.com", 1, "65432109876543210", "Anika Rahman", "Bangladeshi", null, "Dhaka, Bangladesh", 1005 },
                    { 7, 1006, 2006, "9876543225", "54321098765432110", "Rahman Islam", null, "9876543245", "Farid Ahmed", "9876543235", "54321098765432111", "Amina Islam", "Chittagong, Bangladesh", 3, "O-", "9876543215", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rafiul.islam@example.com", 0, "54321098765432109", "Rafiul Islam", "Bangladeshi", null, "Chittagong, Bangladesh", 1006 },
                    { 8, 1007, 2007, "9876543226", "43210987654321099", "Akram Khan", null, "9876543246", "Ayesha Begum", "9876543236", "43210987654321100", "Taslima Khan", "Rajshahi, Bangladesh", 3, "AB-", "9876543216", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zara.khan@example.com", 1, "43210987654321098", "Zara Khan", "Bangladeshi", null, "Rajshahi, Bangladesh", 1007 },
                    { 9, 1008, 2008, "9876543227", "32109876543210988", "Kamal Hossain", null, "9876543247", "Salam Ahmed", "9876543237", "32109876543210989", "Nazma Hossain", "Sylhet, Bangladesh", 3, "A+", "9876543217", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "arif.hossain@example.com", 0, "32109876543210987", "Arif Hossain", "Bangladeshi", null, "Sylhet, Bangladesh", 1008 },
                    { 10, 1009, 2009, "9876543228", "21098765432109877", "Jamil Akter", null, "9876543248", "Khaled Rahman", "9876543238", "21098765432109878", "Rina Akter", "Dhaka, Bangladesh", 4, "A-", "9876543218", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sabrina.akter@example.com", 1, "21098765432109876", "Sabrina Akter", "Bangladeshi", null, "Dhaka, Bangladesh", 1009 },
                    { 11, 1010, 2010, "9876543229", "10987654321098766", "Hasan Mahmud", null, "9876543249", "Farhana Akter", "9876543239", "10987654321098767", "Nazma Hasan", "Chittagong, Bangladesh", 4, "O-", "9876543219", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rahat.hasan@example.com", 0, "10987654321098765", "Rahat Hasan", "Bangladeshi", null, "Chittagong, Bangladesh", 1010 },
                    { 12, 1011, 2011, "9876543230", "09876543210987655", "Rahim Rahman", null, "9876543250", "Kamal Hossain", "9876543240", "09876543210987656", "Sara Rahman", "Rajshahi, Bangladesh", 4, "AB-", "9876543220", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "asif.rahman@example.com", 0, "09876543210987654", "Asif Rahman", "Bangladeshi", null, "Rajshahi, Bangladesh", 1011 },
                    { 13, 1012, 2012, "9876543231", "98765432109876544", "Akram Khan", null, "9876543251", "Ayesha Begum", "9876543241", "98765432109876545", "Taslima Khan", "Sylhet, Bangladesh", 4, "A+", "9876543221", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehnaz.khan@example.com", 1, "98765432109876543", "Mehnaz Khan", "Bangladeshi", null, "Sylhet, Bangladesh", 1012 }
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "SubjectId", "StandardId", "SubjectCode", "SubjectName" },
                values: new object[,]
                {
                    { 1, 1, 101, "Mathematics" },
                    { 2, 1, 102, "Bengali" },
                    { 3, 1, 103, "Physics" },
                    { 4, 2, 201, "Mathematics" },
                    { 5, 2, 202, "Bengali" },
                    { 6, 2, 203, "Physics" },
                    { 7, 3, 301, "Mathematics" },
                    { 8, 3, 302, "Bengali" },
                    { 9, 3, 303, "Physics" },
                    { 10, 4, 401, "Mathematics" },
                    { 11, 4, 402, "Bengali" },
                    { 12, 4, 403, "Physics" }
                });

            migrationBuilder.InsertData(
                table: "Mark",
                columns: new[] { "MarkId", "Feedback", "Grade", "MarkEntryDate", "ObtainedScore", "PassMarks", "PassStatus", "StaffId", "StudentId", "SubjectId", "TotalMarks" },
                values: new object[,]
                {
                    { 1, "Good job!", 1, new DateTime(2024, 5, 1, 19, 1, 10, 724, DateTimeKind.Local).AddTicks(4436), 65, 40, 0, 1, 1, 1, 80 },
                    { 2, "Excellent work!", 0, new DateTime(2024, 5, 1, 19, 1, 10, 724, DateTimeKind.Local).AddTicks(4449), 75, 40, 0, 2, 2, 2, 90 },
                    { 3, "Excellent work!", 0, new DateTime(2024, 5, 1, 19, 1, 10, 724, DateTimeKind.Local).AddTicks(4457), 75, 40, 0, 3, 3, 3, 90 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicMonth_MonthlyPaymentId",
                table: "AcademicMonth",
                column: "MonthlyPaymentId");

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
                name: "IX_DueBalance_MonthlyPaymentId",
                table: "DueBalance",
                column: "MonthlyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DueBalance_StudentId",
                table: "DueBalance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamScheduleStandard_ExamScheduleId",
                table: "ExamScheduleStandard",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamScheduleStandard_StandardId",
                table: "ExamScheduleStandard",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSubject_ExamScheduleStandardId",
                table: "ExamSubject",
                column: "ExamScheduleStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSubject_ExamTypeId",
                table: "ExamSubject",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSubject_SubjectId",
                table: "ExamSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_FeeTypeId",
                table: "Fee",
                column: "FeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_MonthlyPaymentId",
                table: "Fee",
                column: "MonthlyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_OthersPaymentId",
                table: "Fee",
                column: "OthersPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_StandardId",
                table: "Fee",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StaffId",
                table: "Mark",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentId",
                table: "Mark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_SubjectId",
                table: "Mark",
                column: "SubjectId");

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
                name: "IX_MarkEntry_StandardId",
                table: "MarkEntry",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_MarkEntry_SubjectId",
                table: "MarkEntry",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyPayment_StudentId",
                table: "MonthlyPayment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPaymentDetail_OthersPaymentId",
                table: "OtherPaymentDetail",
                column: "OthersPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_OthersPayment_StudentId",
                table: "OthersPayment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_MonthlyPaymentId",
                table: "PaymentDetail",
                column: "MonthlyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMonth_MonthlyPaymentId",
                table: "PaymentMonth",
                column: "MonthlyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_DepartmentId",
                table: "Staff",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_StaffSalaryId",
                table: "Staff",
                column: "StaffSalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UniqueStaffAttendanceNumber",
                table: "Staff",
                column: "UniqueStaffAttendanceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffExperience_StaffId",
                table: "StaffExperience",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StandardId",
                table: "Student",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UniqueStudentAttendanceNumber",
                table: "Student",
                column: "UniqueStudentAttendanceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarksDetails_MarkEntryId",
                table: "StudentMarksDetails",
                column: "MarkEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_StandardId",
                table: "Subject",
                column: "StandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_SubjectCode",
                table: "Subject",
                column: "SubjectCode",
                unique: true,
                filter: "[SubjectCode] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicMonth");

            migrationBuilder.DropTable(
                name: "AcademicYear");

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
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "DueBalance");

            migrationBuilder.DropTable(
                name: "ExamSubject");

            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "OtherPaymentDetail");

            migrationBuilder.DropTable(
                name: "PaymentDetail");

            migrationBuilder.DropTable(
                name: "PaymentMonth");

            migrationBuilder.DropTable(
                name: "StaffExperience");

            migrationBuilder.DropTable(
                name: "StudentMarksDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExamScheduleStandard");

            migrationBuilder.DropTable(
                name: "FeeType");

            migrationBuilder.DropTable(
                name: "OthersPayment");

            migrationBuilder.DropTable(
                name: "MonthlyPayment");

            migrationBuilder.DropTable(
                name: "MarkEntry");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "ExamSchedule");

            migrationBuilder.DropTable(
                name: "ExamType");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "StaffSalary");

            migrationBuilder.DropTable(
                name: "Standard");
        }
    }
}
