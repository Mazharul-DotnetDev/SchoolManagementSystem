

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.SchoolContext
{

   



    public class SchoolDbContext : IdentityDbContext
    {

        public DbSet<AcademicMonth> dbsAcademicMonth { get; set; }
        public DbSet<AcademicYear> dbsAcademicYear { get; set; }
        public DbSet<Admission> dbsAdmission { get; set; }
        public DbSet<Attendance> dbsAttendance { get; set; }
        public DbSet<Classes> dbsClasses { get; set; }
        public DbSet<Employee> dbsEmployee { get; set; }
        public DbSet<EmployeeType> dbsEmployeeType { get; set; }
        public DbSet<Exam> dbsExam { get; set; }
        public DbSet<ExamSchedule> dbsExamSchedule { get; set; }
        public DbSet<FeePayment> dbsFeePayment { get; set; }
        public DbSet<FeeStructure> dbsFeeStructure { get; set; }
        public DbSet<FeeType> dbsFeeType { get; set; }
        public DbSet<Parent> dbsParent { get; set; }
        public DbSet<Resource> dbsResource { get; set; }
        public DbSet<Section> dbsSection { get; set; }
        public DbSet<Session> dbsSession { get; set; }
        public DbSet<Student> dbsStudent { get; set; }
        public DbSet<Subject> dbsSubject { get; set; }
        public DbSet<Enrollment> dbsEnrollment { get; set; }




        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base class implementation of OnModelCreating

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
        .HasKey(e => e.EnrollmentId); // Set EnrollmentId as the primary key for the Enrollment entity

            modelBuilder.Entity<Student>()
              .HasMany(s => s.Enrollments) // One-to-Many relationship: One Student can have many Enrollments
              .WithOne(e => e.Student) // One-to-One relationship: One Enrollment can have one Student
              .HasForeignKey(e => e.StudentId); // Foreign key: Enrollment has a foreign key StudentId

            modelBuilder.Entity<Classes>()
              .HasMany(c => c.Enrollments)
              .WithOne(e => e.Classes)
              .HasForeignKey(e => e.ClassId);

            modelBuilder.Entity<Admission>()
              .HasOne(a => a.Enrollment)
              .WithOne(e => e.Admission)
              .HasForeignKey<Admission>(a => a.EnrollmentId);

        }



    }
}
