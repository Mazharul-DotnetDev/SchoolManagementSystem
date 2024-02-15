using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.DAL.SchoolContext
{

    public class SchoolDbContext : IdentityDbContext
    {

        public DbSet<Attendance> dbsAttendance { get; set; }
        public DbSet<Standard> dbsStandard { get; set; }
        public DbSet<Department> dbsDepartment { get; set; }
        public DbSet<ExamSchedule> dbsExamSchedule { get; set; }
        public DbSet<ExamSubject> dbsExamSubject { get; set; }
        public DbSet<ExamType> dbsExamType { get; set; }
        public DbSet<Mark> dbsMark { get; set; }
        public DbSet<MarkEntry> dbsMarkEntry { get; set; }
        public DbSet<Staff> dbsStaff { get; set; }
        public DbSet<StaffExperience> dbsStaffExperience { get; set; }
        public DbSet<StaffSalary> dbsStaffSalary { get; set; }
        public DbSet<Student> dbsStudent { get; set; }
        public DbSet<Subject> dbsSubject { get; set; }
        public DbSet<FeeType> dbsFeeType { get; set; }
        public DbSet<FeeStructure> dbsFeeStructure { get; set; }
        public DbSet<FeePayment> dbsFeePayment { get; set; }
        public DbSet<DueBalance> dbsDueBalance { get; set; }
        public DbSet<FeePaymentDetail> dbsfeePaymentDetails { get; set; }


        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }


        //This SaveChanges() method is implemented for inserting Computed column [NetSalary column from StaffSalary Table] into Database.
        public override int SaveChanges()
        {
            // Calculate NetSalary before saving changes
            foreach (var entry in ChangeTracker.Entries<StaffSalary>())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    var staffSalary = entry.Entity;
                    staffSalary.CalculateNetSalary();
                }
            }
            

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




            //    modelBuilder.Entity<StaffExperience>()
            //.Property(p => p.ServiceDuration)
            //.HasComputedColumnSql("DATEDIFF(year, JoiningDate, ISNULL(LeavingDate, GETDATE()))"); // Calculate duration in years



            modelBuilder.Entity<Subject>()
        .HasIndex(s => s.SubjectCode)
        .IsUnique();


            modelBuilder.Entity<Student>()
        .HasIndex(s => s.AdmissionNo)
        .IsUnique();


            modelBuilder.Entity<Student>()
        .HasIndex(s => s.EnrollmentNo)
        .IsUnique();


        }
    }
}
