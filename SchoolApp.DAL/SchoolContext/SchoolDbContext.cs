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
        public DbSet<ClassRoom> dbsClassRoom { get; set; }
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





        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

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
                .OnDelete(DeleteBehavior.NoAction)
                ; // Specify ON DELETE NO ACTION



        }
    }
}
