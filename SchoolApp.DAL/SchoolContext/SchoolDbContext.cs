using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models.DataModels;
using SchoolApp.Models.DataModels.SecurityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.SchoolContext
{


    //public class SchoolDbContext : IdentityDbContext

    public class SchoolDbContext : IdentityDbContext<ApplicationUser>
    {

        #region DbSets
        public DbSet<Attendance> dbsAttendance { get; set; }

        //public DbSet<StudentAttendance> dbsStudentAttendance { get; set; }
        //public DbSet<StaffAttendance> dbsStaffAttendance { get; set; }

        public DbSet<Standard> dbsStandard { get; set; }
        public DbSet<Department> dbsDepartment { get; set; }
        public DbSet<ExamSchedule> dbsExamSchedule { get; set; }
        public DbSet<ExamSubject> dbsExamSubject { get; set; }
        public DbSet<ExamType> dbsExamType { get; set; }
        public DbSet<Mark> dbsMark { get; set; }       
        public DbSet<Staff> dbsStaff { get; set; }
        public DbSet<StaffExperience> dbsStaffExperience { get; set; }
        public DbSet<StaffSalary> dbsStaffSalary { get; set; }
        public DbSet<Student> dbsStudent { get; set; }
        public DbSet<Subject> dbsSubject { get; set; }
        public DbSet<FeeType> dbsFeeType { get; set; }       
        public DbSet<DueBalance> dbsDueBalance { get; set; }        
        public DbSet<AcademicMonth> dbsAcademicMonths { get; set; }
        public DbSet<AcademicYear> dbsAcademicYears { get; set; }
        public DbSet<Fee> fees { get; set; }
        public DbSet<MonthlyPayment> monthlyPayments { get; set; }
        public DbSet<OthersPayment> othersPayments { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<OtherPaymentDetail> otherPaymentDetails { get; set; }
        public DbSet<PaymentMonth> paymentMonths { get; set; }
        public DbSet<ExamScheduleStandard> dbsExamScheduleStandard { get; set; }

        #endregion

        #region Constructor
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        } 
        #endregion

        //This SaveChanges() method is implemented for inserting Computed column [NetSalary column from StaffSalary Table] into Database.
        public override int SaveChanges()
        {


            //foreach (var entry in ChangeTracker.Entries())
            //{
            //    if (entry.Entity is StaffSalary staffSalary && (entry.State == EntityState.Added || entry.State == EntityState.Modified))
            //    {
            //        // Update NetSalary before saving changes
            //        staffSalary.NetSalary = CalculateNetSalary(staffSalary);
            //    }
            //}


            // Calculate NetSalary before saving changes
            //foreach (var entry in ChangeTracker.Entries<StaffSalary>())
            //{
            //    if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            //    {
            //        var staffSalary = entry.Entity;
            //        staffSalary.CalculateNetSalary();
            //    }
            //}

            #region Testing_Purpose
            // Validation logic before saving changes

            //var validationErrors = GetValidationErrors();
            //if (validationErrors.Any())
            //{
            //    // Rollback changes
            //    // You can use transaction rollback or any other mechanism here
            //    throw new InvalidOperationException("Validation failed. Changes rolled back.");
            //}

            // Save changes if validation passes 
            #endregion

            return base.SaveChanges();
        }       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(u => new { u.UserId, u.LoginProvider, u.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
        .HasKey(r => new { r.UserId, r.RoleId });


            // Configure the foreign key constraint for dbsMark referencing dbsSubject

            modelBuilder.Entity<Mark>()
                .HasOne(m => m.Subject)
                .WithMany()
                .HasForeignKey(m => m.SubjectId)
                .OnDelete(DeleteBehavior.NoAction);
            // Specify ON DELETE NO ACTION
            


            #region Index
            modelBuilder.Entity<Subject>()
            .HasIndex(s => s.SubjectCode)
            .IsUnique();

                modelBuilder.Entity<Student>()
            .HasIndex(s => s.AdmissionNo)
            .IsUnique();

                modelBuilder.Entity<Student>()
            .HasIndex(s => s.EnrollmentNo)
            .IsUnique();
            
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.UniqueStudentAttendanceNumber)
                .IsUnique();
          
            modelBuilder.Entity<Staff>()
                .HasIndex(s => s.UniqueStaffAttendanceNumber)
                .IsUnique();

            #endregion

            #region Seed Data

            // ----------------------------------------------- //
            #region AcademicMonth
            modelBuilder.Entity<AcademicMonth>().HasData(
               new AcademicMonth { MonthId = 1, MonthName = "January" },
               new AcademicMonth { MonthId = 2, MonthName = "February" },
               new AcademicMonth { MonthId = 3, MonthName = "March" },
               new AcademicMonth { MonthId = 4, MonthName = "April" },
               new AcademicMonth { MonthId = 5, MonthName = "May" },
               new AcademicMonth { MonthId = 6, MonthName = "June" },
               new AcademicMonth { MonthId = 7, MonthName = "July" },
               new AcademicMonth { MonthId = 8, MonthName = "August" },
               new AcademicMonth { MonthId = 9, MonthName = "September" },
               new AcademicMonth { MonthId = 10, MonthName = "October" },
               new AcademicMonth { MonthId = 11, MonthName = "November" },
               new AcademicMonth { MonthId = 12, MonthName = "December" }
           );
            for (int year = 2000; year <= 2050; year++)
            {
                modelBuilder.Entity<AcademicYear>().HasData(
                    new AcademicYear { AcademicYearId = year - 2000 + 1, Name = year.ToString() }
                );
            }
            #endregion
            // ----------------------------------------------- //
            #region Attendance
            // Seed Attendance data
            modelBuilder.Entity<Attendance>().HasData(
                new Attendance
                {
                    AttendanceId = 1,
                    IsPresent = true
                    //,
                    //Staffs = new Staff[]
                    //{
                    //new Staff { StaffId = 1},
                    //new Staff { StaffId = 2}
                    //},
                    //Students = new Student[]
                    //{
                    //new Student { StudentId = 1 },
                    //new Student { StudentId = 2 }
                    //}
                },
                new Attendance
                {
                    AttendanceId = 2,
                    IsPresent = true
                    //,
                    //Staffs = new Staff[]
                    //{
                    //new Staff { StaffId = 3},
                    //new Staff { StaffId = 3}
                    //},
                    //Students = new Student[]
                    //{
                    //new Student { StudentId = 3},
                    //new Student { StudentId = 2 }
                    //}
                },
                new Attendance
                {
                    AttendanceId = 3,
                    IsPresent = true
                    //,
                    //Staffs = new List<Staff>
                    //{
                    //new Staff { StaffId = 1},
                    //new Staff { StaffId = 2}
                    //},
                    //Students = new List<Student>
                    //{
                    //new Student { StudentId = 1},
                    //new Student { StudentId = 2 }
                    //}
                },
                new Attendance
                {
                    AttendanceId = 4,
                    IsPresent = true
                    //,
                    //Staffs = new Staff[]
                    //{
                    //new Staff { StaffId = 1},
                    //new Staff { StaffId = 2}
                    //},
                    //Students = new Student[]
                    //{
                    //new Student { StudentId = 1 },
                    //new Student { StudentId = 2 }
                    //}
                }
            );
            #endregion
            // ----------------------------------------------- //
            #region Department
            // Seed Department data
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );
            #endregion
            // ----------------------------------------------- //
            #region DueBalance_Excluded
            // Seed DueBalance data
            //modelBuilder.Entity<DueBalance>().HasData(
            //    new DueBalance { DueBalanceId = 1, StudentId = 1 },
            //    new DueBalance { DueBalanceId = 2, StudentId = 2 },
            //    new DueBalance { DueBalanceId = 3, StudentId = 3 }
            //);
            #endregion
            // ----------------------------------------------- //
            #region ExamSchedule
            // Seed ExamSchedule data along with associated ExamSubjects
            modelBuilder.Entity<ExamSchedule>().HasData(
                new ExamSchedule
                {
                    ExamScheduleId = 1,
                    ExamScheduleName = "Midterm Exam"
                    //ExamTypeId = 1
                    //,
                    //ExamSubjects = new List<ExamSubject>
                    //{
                    //new ExamSubject { ExamSubjectId = 1},
                    //new ExamSubject { ExamSubjectId = 2}
                    //}
                },
                new ExamSchedule
                {
                    ExamScheduleId = 2,
                    ExamScheduleName = "Final Exam"
                    //ExamTypeId = 2
                    //,
                    //ExamSubjects = new List<ExamSubject>
                    //{
                    //new ExamSubject { ExamSubjectId = 1},
                    //new ExamSubject { ExamSubjectId = 2 }
                    //}
                },
                new ExamSchedule
                {
                    ExamScheduleId = 3,
                    ExamScheduleName = "Practical Exam"
                    //ExamTypeId = 3
                    //,
                    //ExamSubjects = new List<ExamSubject>
                    //{
                    //new ExamSubject { ExamSubjectId = 2},
                    //new ExamSubject { ExamSubjectId = 3 }
                    //}
                }
            );
            #endregion
            // ----------------------------------------------- //

            #region ExamType
            // Seed ExamType data
            modelBuilder.Entity<ExamType>().HasData(
                new ExamType { ExamTypeId = 1, ExamTypeName = "Midterm" },
                new ExamType { ExamTypeId = 2, ExamTypeName = "Final" },
                new ExamType { ExamTypeId = 3, ExamTypeName = "Practical" }
            );
            #endregion


            // ----------------------------------------------- //
            #region ExamSubject
            // Seed ExamSubject data
            //            modelBuilder.Entity<ExamSubject>().HasData(
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 1,
            //                //ExamScheduleStandardId = 1,
            //                //SubjectId = 1,
            //                //ExamTypeId = 1,
            //                ExamDate = DateTime.Now.Date,
            //                ExamStartTime = new TimeSpan(9, 0, 0), // 9:00 AM
            //                ExamEndTime = new TimeSpan(11, 0, 0)  // 11:00 AM
            //            },
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 2,
            //                //ExamScheduleStandardId = 2,
            //                //SubjectId = 2,
            //                //ExamTypeId = 2,
            //                ExamDate = DateTime.Now.Date.AddDays(1), // Tomorrow
            //                ExamStartTime = new TimeSpan(10, 0, 0),  // 10:00 AM
            //                ExamEndTime = new TimeSpan(12, 0, 0)   // 12:00 PM
            //            },
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 3,
            //                //ExamScheduleStandardId = 3,
            //                //SubjectId = 3,
            //                //ExamTypeId = 3,
            //                ExamDate = DateTime.Now.Date.AddDays(2), // Day after tomorrow
            //                ExamStartTime = new TimeSpan(11, 0, 0),  // 11:00 AM
            //                ExamEndTime = new TimeSpan(13, 0, 0)   // 1:00 PM
            //            },
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 4,
            //                //ExamScheduleStandardId = 1,
            //                //SubjectId = 1,
            //                //ExamTypeId = 1,
            //                ExamDate = DateTime.Now.Date.AddDays(3), // Three days from now
            //                ExamStartTime = new TimeSpan(9, 0, 0),   // 9:00 AM
            //                ExamEndTime = new TimeSpan(11, 0, 0)    // 11:00 AM
            //            },
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 5,
            //                //ExamScheduleStandardId = 2,
            //                //SubjectId = 2,
            //                //ExamTypeId = 1,
            //                ExamDate = DateTime.Now.Date.AddDays(4), // Four days from now
            //                ExamStartTime = new TimeSpan(10, 0, 0),  // 10:00 AM
            //                ExamEndTime = new TimeSpan(12, 0, 0)    // 12:00 PM
            //            },
            //            new ExamSubject
            //            {
            //                ExamSubjectId = 6,
            //                //ExamScheduleStandardId = 3,
            //                //SubjectId = 3,
            //                //ExamTypeId = 2,
            //                ExamDate = DateTime.Now.Date.AddDays(5), // Five days from now
            //                ExamStartTime = new TimeSpan(11, 0, 0),  // 11:00 AM
            //                ExamEndTime = new TimeSpan(13, 0, 0)    // 1:00 PM
            //            }
            //);

            #endregion
            // ----------------------------------------------- //        
            #region FeePaymentDetail
            // Seed FeePaymentDetail data
            //modelBuilder.Entity<FeePaymentDetail>().HasData(
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 1,
            //        FeePaymentId = 1,
            //        FeeTypeName = "Tuition Fee",
            //        FeeAmount = 500
            //    },
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 2,
            //        FeePaymentId = 2,
            //        FeeTypeName = "Library Fee",
            //        FeeAmount = 100
            //    },
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 3,
            //        FeePaymentId = 3,
            //        FeeTypeName = "Sports Fee",
            //        FeeAmount = 600
            //    },
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 4,
            //        FeePaymentId = 1,
            //        FeeTypeName = "Picnic Fee",
            //        FeeAmount = 200
            //    },
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 5,
            //        FeePaymentId = 2,
            //        FeeTypeName = "Party Fee",
            //        FeeAmount = 700
            //    },
            //    new FeePaymentDetail
            //    {
            //        FeePaymentDetailId = 6,
            //        FeePaymentId = 3,
            //        FeeTypeName = "Exam Fee",
            //        FeeAmount = 250
            //    }
            //);
            #endregion
            // ----------------------------------------------- //
            #region FeePayment
            // Seed FeePayment data
            //modelBuilder.Entity<FeePayment>().HasData(
            //    new FeePayment
            //    {
            //        FeePaymentId = 1,
            //        StudentId = 1,
            //        StudentName = "John Doe",
            //        TotalFeeAmount = 1000,
            //        Discount = 10,
            //        AmountAfterDiscount = 900,
            //        PreviousDue = 0,
            //        TotalAmount = 900,
            //        AmountPaid = 500,
            //        AmountRemaining = 400,
            //        PaymentDate = DateTime.Now
            //        //,
            //        //FeeStructures = new List<FeeStructure>
            //        //{
            //        //new FeeStructure { FeeStructureId = 1},
            //        //new FeeStructure { FeeStructureId = 2}
            //        //}
            //        //,
            //        //FeePaymentDetails = new List<FeePaymentDetail>
            //        //{
            //        //new FeePaymentDetail { FeePaymentDetailId = 1},
            //        //new FeePaymentDetail { FeePaymentDetailId = 2 }
            //        //}
            //    },
            //    new FeePayment
            //    {
            //        FeePaymentId = 2,
            //        StudentId = 2,
            //        StudentName = "Jane Doe",
            //        TotalFeeAmount = 1500,
            //        Discount = 200,
            //        AmountAfterDiscount = 1300,
            //        PreviousDue = 100,
            //        TotalAmount = 1400,
            //        AmountPaid = 1400,
            //        AmountRemaining = 0,
            //        PaymentDate = DateTime.Now
            //        //,
            //        //FeeStructures = new List<FeeStructure>
            //        //{
            //        //new FeeStructure { FeeStructureId = 1},
            //        //new FeeStructure { FeeStructureId = 2}
            //        //}
            //        //,
            //        //FeePaymentDetails = new List<FeePaymentDetail>
            //        //{
            //        //new FeePaymentDetail { FeePaymentDetailId = 1},
            //        //new FeePaymentDetail { FeePaymentDetailId = 2 }
            //        //}
            //    },
            //    new FeePayment
            //    {
            //        FeePaymentId = 3,
            //        StudentId = 3,
            //        StudentName = "Alice Smith",
            //        TotalFeeAmount = 1200,
            //        Discount = 0,
            //        AmountAfterDiscount = 1200,
            //        PreviousDue = 50,
            //        TotalAmount = 1250,
            //        AmountPaid = 1250,
            //        AmountRemaining = 0,
            //        PaymentDate = DateTime.Now
            //        //,
            //        //FeeStructures = new List<FeeStructure>
            //        //{
            //        //new FeeStructure { FeeStructureId = 1},
            //        //new FeeStructure { FeeStructureId = 2}
            //        //}
            //        //,
            //        //FeePaymentDetails = new List<FeePaymentDetail>
            //        //{
            //        //new FeePaymentDetail { FeePaymentDetailId = 1},
            //        //new FeePaymentDetail { FeePaymentDetailId = 2 }
            //        //}
            //    }
            //);
            #endregion
            // ----------------------------------------------- //
            #region FeeStructure
            // Seed FeeStructure data
            //modelBuilder.Entity<FeeStructure>().HasData(
            //    new FeeStructure
            //    {
            //        FeeStructureId = 1,
            //        FeeTypeId = 1,
            //        TypeName = "Registration Fee",
            //        StandardId = 1,
            //        StandardName = "Grade 1",
            //        Monthly = false,
            //        Yearly = true,
            //        FeeAmount = 500
            //    },
            //    new FeeStructure
            //    {
            //        FeeStructureId = 2,
            //        FeeTypeId = 2,
            //        TypeName = "Tuition Fee",
            //        StandardId = 2,
            //        StandardName = "Grade 2",
            //        Monthly = true,
            //        Yearly = false,
            //        FeeAmount = 1000
            //    },
            //    new FeeStructure
            //    {
            //        FeeStructureId = 3,
            //        FeeTypeId = 3,
            //        TypeName = "Library Fee",
            //        StandardId = 3,
            //        StandardName = "Grade 3",
            //        Monthly = false,
            //        Yearly = true,
            //        FeeAmount = 200
            //    }
            //);
            #endregion
            // ----------------------------------------------- //
            #region FeeType
            // Seed FeeType data
            modelBuilder.Entity<FeeType>().HasData(
                new FeeType
                {
                    FeeTypeId = 1,
                    TypeName = "Registration Fee"
                },
                new FeeType
                {
                    FeeTypeId = 2,
                    TypeName = "Tuition Fee"
                },
                new FeeType
                {
                    FeeTypeId = 3,
                    TypeName = "Library Fee"
                }
            );
            #endregion
            // ----------------------------------------------- //
            #region Mark
            // Seed Mark data
            modelBuilder.Entity<Mark>().HasData(
                new Mark
                {
                    MarkId = 1,
                    TotalMarks = 80,
                    PassMarks = 40,
                    ObtainedScore = 65,
                    Grade = Grade.B,
                    PassStatus = Pass.Passed,
                    MarkEntryDate = DateTime.Now,
                    Feedback = "Good job!",
                    StaffId = 1,
                    StudentId = 1,
                    SubjectId = 1
                },
                new Mark
                {
                    MarkId = 2,
                    TotalMarks = 90,
                    PassMarks = 40,
                    ObtainedScore = 75,
                    Grade = Grade.A,
                    PassStatus = Pass.Passed,
                    MarkEntryDate = DateTime.Now,
                    Feedback = "Excellent work!",
                    StaffId = 2,
                    StudentId = 2,
                    SubjectId = 2
                },
                new Mark
                {
                    MarkId = 3,
                    TotalMarks = 90,
                    PassMarks = 40,
                    ObtainedScore = 75,
                    Grade = Grade.A,
                    PassStatus = Pass.Passed,
                    MarkEntryDate = DateTime.Now,
                    Feedback = "Excellent work!",
                    StaffId = 3,
                    StudentId = 3,
                    SubjectId = 3
                }
                // Add more seed data as needed
            );
            #endregion
            // ----------------------------------------------- //
            #region MarkEntry_Excluded
            // Seed MarkEntry data along with associated Marks
            //modelBuilder.Entity<MarkEntry>().HasData(
            //    new MarkEntry
            //    {
            //        MarkEntryId = 1,
            //        MarkEntryDate = DateTime.Now,
            //        StaffId = 1,
            //        SubjectId = 1
            //        //    , 
            //        //    Marks = new List<Mark>
            //        //    {
            //        //new Mark
            //        //{
            //        //    MarkId = 1
            //        //},
            //        //new Mark
            //        //{
            //        //    MarkId = 2
            //        //}
            //        //    }
            //    }
            //    ,
            //    new MarkEntry
            //    {
            //        MarkEntryId = 2,
            //        MarkEntryDate = DateTime.Now,
            //        StaffId = 2,
            //        SubjectId = 2
            //        //    , 
            //        //    Marks = new List<Mark>
            //        //    {
            //        //new Mark
            //        //{
            //        //    MarkId = 2
            //        //}

            //        //    }
            //    }
            //    ,
            //    new MarkEntry
            //    {
            //        MarkEntryId = 3,
            //        MarkEntryDate = DateTime.Now,
            //        StaffId = 3,
            //        SubjectId = 3
            //        //    ,
            //        //    Marks = new List<Mark>
            //        //    {
            //        //new Mark
            //        //{
            //        //    MarkId = 2
            //        //}

            //        //    }
            //    }

            //);
            #endregion
            // ----------------------------------------------- //
            #region Staff_Excluded
            // Seed Staff data if required
            //modelBuilder.Entity<Staff>().HasData(
            //    new Staff
            //    {
            //        StaffId = 1,
            //        StaffName = "John Doe",
            //        UniqueStaffAttendanceNumber = 2000,
            //        Gender = Gender.Male,
            //        DepartmentId = 1,
            //        Status = "Active",
            //        StaffSalaryId = 1
            //        //,
            //        //StaffExperiences = new List<StaffExperience>
            //        //{
            //        //new StaffExperience { StaffExperienceId = 1},
            //        //new StaffExperience { StaffExperienceId = 2}
            //        //},

            //    },
            //    new Staff
            //    {
            //        StaffId = 2,
            //        StaffName = "Jane Smith",
            //        UniqueStaffAttendanceNumber = 2001,
            //        Gender = Gender.Female,
            //        DepartmentId = 2,
            //        Status = "Active",
            //        StaffSalaryId = 2

            //        //,
            //        //StaffExperiences = new List<StaffExperience>
            //        //{
            //        //new StaffExperience { StaffExperienceId = 1},
            //        //new StaffExperience { StaffExperienceId = 2}
            //        //}

            //    },
            //    new Staff
            //    {
            //        StaffId = 3,
            //        StaffName = "Jane Smith",
            //        UniqueStaffAttendanceNumber = 2002,
            //        Gender = Gender.Female,
            //        DepartmentId = 3,
            //        Status = "Active",
            //        StaffSalaryId = 3
            //        //,
            //        //StaffExperiences = new List<StaffExperience>
            //        //{
            //        //new StaffExperience { StaffExperienceId = 1},
            //        //new StaffExperience { StaffExperienceId = 2}
            //        //}

            //    }
            //);
            #endregion
            // ----------------------------------------------- //
            #region StaffExperience_Excluded
            // Seed StaffExperience data if required
            //modelBuilder.Entity<StaffExperience>().HasData(
            //    new StaffExperience
            //    {
            //        StaffExperienceId = 1,
            //        CompanyName = "ABC School",
            //        Designation = "Teacher",
            //        Responsibilities = "Teaching Mathematics and Physics",
            //        Achievements = "Improved student performance by 20%",
            //    },
            //    new StaffExperience
            //    {
            //        StaffExperienceId = 2,
            //        CompanyName = "ABC School",
            //        Designation = "Teacher",
            //        Responsibilities = "Teaching Mathematics and Physics",
            //        Achievements = "Improved student performance by 20%",
            //    },
            //    new StaffExperience
            //    {
            //        StaffExperienceId = 3,
            //        CompanyName = "ABC School",
            //        Designation = "Teacher",
            //        Responsibilities = "Teaching Mathematics and Physics",
            //        Achievements = "Improved student performance by 20%",
            //    }

            //);
            #endregion
            // ----------------------------------------------- //
            #region StaffSalary
            // Seed StaffSalary data if required
            modelBuilder.Entity<StaffSalary>().HasData(
                new StaffSalary
                {
                    StaffSalaryId = 1,
                    StaffName = "Jamir King",
                    BasicSalary = 5000,
                    FestivalBonus = 1000,
                    Allowance = 500,
                    MedicalAllowance = 300,
                    HousingAllowance = 800,
                    TransportationAllowance = 200,
                    SavingFund = 200,
                    Taxes = 500,
                },
               new StaffSalary
               {
                   StaffSalaryId = 2,
                   StaffName = "Jamir Jamidar",
                   BasicSalary = 5000,
                   FestivalBonus = 1000,
                   Allowance = 500,
                   MedicalAllowance = 300,
                   HousingAllowance = 800,
                   TransportationAllowance = 200,
                   SavingFund = 200,
                   Taxes = 500,
               },
               new StaffSalary
               {
                   StaffSalaryId = 3,
                   StaffName = "Jamir Amir",
                   BasicSalary = 5000,
                   FestivalBonus = 1000,
                   Allowance = 500,
                   MedicalAllowance = 300,
                   HousingAllowance = 800,
                   TransportationAllowance = 200,
                   SavingFund = 200,
                   Taxes = 500,
               }
            );
            #endregion
            // ----------------------------------------------- //
            #region Standard
            // Seed Standard data if required
            modelBuilder.Entity<Standard>().HasData(
                new Standard
                {
                    StandardId = 1,
                    StandardName = "Standard 1",
                    StandardCapacity = "30 students",
                },
                new Standard
                {
                    StandardId = 2,
                    StandardName = "Standard 2",
                    StandardCapacity = "35 students",
                },
                 new Standard
                 {
                     StandardId = 3,
                     StandardName = "Standard 2",
                     StandardCapacity = "35 students",
                 }

            );
            #endregion
            // ----------------------------------------------- //
            #region Student
            // Seed Student data if required
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    StudentId = 1,
                    AdmissionNo = 1000,
                    EnrollmentNo = 2000,
                    UniqueStudentAttendanceNumber = 1000,
                    StudentName = "John Doe",
                    StudentGender = GenderList.Male,
                    StudentBloodGroup = "A+",
                    StudentNationality = "American",
                    StudentNIDNumber = "17948678987654320",
                    StudentContactNumber1 = "1234567890",
                    StudentEmail = "john.doe@example.com",
                    PermanentAddress = "123 Main Street, City, Country",
                    TemporaryAddress = "456 Elm Street, City, Country",
                    FatherName = "Michael Doe",
                    FatherNID = "17948678987624322",
                    FatherContactNumber = "9876543210",
                    MotherName = "Alice Doe",
                    MotherNID = "17948678987754322",
                    MotherContactNumber = "9876543220",
                    LocalGuardianName = "Jane Smith",
                    LocalGuardianContactNumber = "9876543230",
                    StandardId = 1,
                },

                new Student
                {
                    StudentId = 2,
                    AdmissionNo = 1001,
                    EnrollmentNo = 2001,
                    UniqueStudentAttendanceNumber = 1001,
                    StudentName = "John Doe",
                    StudentGender = GenderList.Male,
                    StudentBloodGroup = "A+",
                    StudentNationality = "American",
                    StudentNIDNumber = "17948678987654322",
                    StudentContactNumber1 = "1234567890",
                    StudentEmail = "john.doe@example.com",
                    PermanentAddress = "123 Main Street, City, Country",
                    TemporaryAddress = "456 Elm Street, City, Country",
                    FatherName = "Michael Doe",
                    FatherNID = "17948578987654322",
                    FatherContactNumber = "9876543210",
                    MotherName = "Alice Doe",
                    MotherNID = "17948674987654322",
                    MotherContactNumber = "9876543220",
                    LocalGuardianName = "Jane Smith",
                    LocalGuardianContactNumber = "9876543230",
                    StandardId = 2,
                },
                new Student
                {
                    StudentId = 3,
                    AdmissionNo = 1002,
                    EnrollmentNo = 2002,
                    UniqueStudentAttendanceNumber = 1002,
                    StudentName = "John Doe",
                    StudentGender = GenderList.Male,
                    StudentBloodGroup = "A+",
                    StudentNationality = "American",
                    StudentNIDNumber = "17945678987654322",
                    StudentContactNumber1 = "1234567890",
                    StudentEmail = "john.doe@example.com",
                    PermanentAddress = "123 Main Street, City, Country",
                    TemporaryAddress = "456 Elm Street, City, Country",
                    FatherName = "Michael Doe",
                    FatherNID = "17345678987654322",
                    FatherContactNumber = "9876543210",
                    MotherName = "Alice Doe",
                    MotherNID = "12345678987654322",
                    MotherContactNumber = "9876543220",
                    LocalGuardianName = "Jane Smith",
                    LocalGuardianContactNumber = "9876543230",
                    StandardId = 3,
                }
            );
            #endregion
            // ----------------------------------------------- //
            #region Subject
            // Seed Subject data if required
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    SubjectId = 1,
                    SubjectName = "Mathematics",
                    SubjectCode = 101,
                    StandardId = 1
                },
                new Subject
                {
                    SubjectId = 2,
                    SubjectName = "Physics",
                    SubjectCode = 102,
                    StandardId = 2
                },
                new Subject
                {
                    SubjectId = 3,
                    SubjectName = "Chemistry",
                    SubjectCode = 103,
                    StandardId = 3
                },
                new Subject
                {
                    SubjectId = 4,
                    SubjectName = "Biology",
                    SubjectCode = 104,
                    StandardId = 1
                },
                new Subject
                {
                    SubjectId = 5,
                    SubjectName = "Computer Science",
                    SubjectCode = 105,
                    StandardId = 2
                },
                new Subject
                {
                    SubjectId = 6,
                    SubjectName = "Electronics",
                    SubjectCode = 106,
                    StandardId = 3
                }

            );
            #endregion
            // ----------------------------------------------- //
            #region StudentAttendance_Excluded
            // Seed StudentAttendance data if required
            //modelBuilder.Entity<StudentAttendance>().HasData(
            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 1,
            //        WorkingDate = new DateOnly(2024, 04, 08)
            //    },

            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 2,
            //        WorkingDate = new DateOnly(2024, 04, 09)
            //    },
            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 3,
            //        WorkingDate = new DateOnly(2024, 04, 10)
            //    },
            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 4
            //    },
            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 5
            //    },
            //    new StudentAttendance
            //    {
            //        StudentAttendanceId = 6
            //    }

            //);
            #endregion
            // ----------------------------------------------- //
            #region StaffAttendance_Excluded
            // Seed StaffAttendance data if required
            //modelBuilder.Entity<StaffAttendance>().HasData(
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 1,
            //        WorkingDate = new DateOnly(2024, 04, 08)
            //    },
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 2,
            //        WorkingDate = new DateOnly(2024, 04, 09)
            //    },
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 3,
            //        WorkingDate = new DateOnly(2024, 04, 10)
            //    },
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 4
            //    },
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 5
            //    },
            //    new StaffAttendance
            //    {
            //        StaffAttendanceId = 6
            //    }

            //); 
            #endregion
            //-----------------------------------------//
            #region StaffExperience_Excluded
            modelBuilder.Entity<StaffExperience>().HasData(
    new StaffExperience
    {
        StaffExperienceId = 1,
        CompanyName = "ABC Company",
        Designation = "Software Engineer",
        JoiningDate = new DateTime(2020, 5, 10),
        LeavingDate = new DateTime(2022, 8, 15),
        Responsibilities = "Developed web applications.",
        Achievements = "Received Employee of the Month award."
    },
    new StaffExperience
    {
        StaffExperienceId = 2,
        CompanyName = "XYZ Corporation",
        Designation = "Data Analyst",
        JoiningDate = new DateTime(2018, 9, 20),
        LeavingDate = new DateTime(2020, 4, 30),
        Responsibilities = "Analyzed data to provide insights.",
        Achievements = "Implemented a new data visualization system."
    },
    new StaffExperience
    {
        StaffExperienceId = 3,
        CompanyName = "EFG Ltd.",
        Designation = "Project Manager",
        JoiningDate = new DateTime(2016, 3, 5),
        LeavingDate = new DateTime(2018, 7, 25),
        Responsibilities = "Led a team of developers.",
        Achievements = "Successfully delivered multiple projects on time."
    }
    // Add more seed data as needed
);

            #endregion
            //-----------------------------------------//
            #region Staff
            modelBuilder.Entity<Staff>().HasData(
               new Staff
               {
                   StaffId = 1,
                   StaffName = "Jamir King",
                   UniqueStaffAttendanceNumber = 201,
                   Gender = Gender.Male,
                   DOB = new DateTime(1985, 5, 15),
                   FatherName = "Michael Doe",
                   MotherName = "Alice Doe",
                   TemporaryAddress = "Temporary Address",
                   PermanentAddress = "Permanent Address",
                   ContactNumber1 = "1234567890",
                   Email = "john.doe@example.com",
                   ImagePath = "path/to/image.jpg",
                   Qualifications = "Bachelor's in Computer Science",
                   JoiningDate = new DateTime(2010, 7, 1),
                   Designation = Designation.Counselor,
                   BankAccountName = "John Doe",
                   BankAccountNumber = 1234567890,
                   BankName = "ABC Bank",
                   BankBranch = "XYZ Branch",
                   Status = "Active",
                   DepartmentId = 1,
                   StaffSalaryId = 1
               },
               new Staff
               {
                   StaffId = 2,
                   StaffName = "Jamir Jamidar",
                   UniqueStaffAttendanceNumber = 202,
                   Gender = Gender.Female,
                   DOB = new DateTime(1990, 8, 20),
                   FatherName = "David Smith",
                   MotherName = "Emily Smith",
                   TemporaryAddress = "Temporary Address",
                   PermanentAddress = "Permanent Address",
                   ContactNumber1 = "9876543210",
                   Email = "alice.smith@example.com",
                   ImagePath = "path/to/image.jpg",
                   Qualifications = "Master's in Education",
                   JoiningDate = new DateTime(2015, 9, 15),
                   Designation = Designation.Headmistress,
                   BankAccountName = "Alice Smith",
                   BankAccountNumber = 9873210,
                   BankName = "DEF Bank",
                   BankBranch = "UVW Branch",
                   Status = "Active",
                   DepartmentId = 2,
                   StaffSalaryId = 2
               },
               new Staff
               {
                   StaffId = 3,
                   StaffName = "Jamir Amir",
                   UniqueStaffAttendanceNumber = 203,
                   Gender = Gender.Male,
                   DOB = new DateTime(1980, 01, 01),
                   FatherName = "Richard Doe",
                   MotherName = "Jane Doe",
                   TemporaryAddress = "123 Main Street, Anytown",
                   PermanentAddress = "456 Elm Street, Anytown",
                   ContactNumber1 = "555-123-4567",
                   Email = "john.doe@example.com",
                   Qualifications = "Bachelor of Science in Mathematics",
                   JoiningDate = new DateTime(2020, 08, 15),
                   Designation = Designation.Professor,
                   BankAccountName = "John Doe",
                   BankAccountNumber = 1234567890,
                   BankName = "Anytown Bank",
                   BankBranch = "Main Street",
                   Status = "Active",
                   DepartmentId = 3,
                   StaffSalaryId = 3
               }

           );
            #endregion
            //-----------------------------------------//


            #endregion
        }
    }
}