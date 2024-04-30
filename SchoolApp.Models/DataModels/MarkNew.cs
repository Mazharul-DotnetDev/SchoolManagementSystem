﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolApp.Models.DataModels
{
    [Table("MarkEntry")] // not migrated yet
    public class MarkEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MarkEntryId { get; set; }

        public DateTime? MarkEntryDate { get; set; } = DateTime.Now;

        public int StaffId { get; set; }
        public Staff? Staff { get; set; }


        // 1st Semester, 2nd Semester
        public int ExamScheduleId { get; set; }
        public ExamSchedule? ExamSchedule { get; set; }



        // Oral, Writen, MCQ
        public int ExamTypeId { get; set; }
        public ExamType? ExamType { get; set; }

        

        // Class 1, Class 2
        //public int ExamScheduleStandardId { get; set; }
        //public ExamScheduleStandard? ExamScheduleStandard { get; set; }


        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }


        public int StandardId { get; set; }
        public Standard? Standard { get; set; }


        // Bengali, 
        //public int ExamSubjectId { get; set; }
        //public ExamSubject? ExamSubject { get; set; }

        public int TotalMarks { get; set; }
        public int PassMarks { get; set; }


        //public virtual ICollection<Student>? Students { get; set; } = [];


        public virtual ICollection<StudentMarksDetails> StudentMarksDetails { get; set; } = [];

    }

    #region CollectionSeedData
    /*
   update Student
Set [MarkEntryId] = 1
where StudentId =1
go
update Student
Set [MarkEntryId] = 1
where StudentId =2
go
update Student
Set [MarkEntryId] = 1
where StudentId =3
go
update Student
Set [MarkEntryId] = 2
where StudentId =4
go
update Student
Set [MarkEntryId] = 2
where StudentId =5
go
update Student
Set [MarkEntryId] = 2
where StudentId =6

*/
    #endregion


    #region NewMarksSeedData
    //    -- Insert dummy data into MarkEntry table
    //INSERT INTO[SchoolSystemDb].[dbo].[MarkEntry]
    //    ( [MarkEntryDate], [StaffId], [ExamScheduleId], [ExamTypeId], [SubjectId], [StandardId], [TotalMarks], [PassMarks])
    //VALUES
    //    ( '2024-04-01', 1, 1, 1, 1, 1, 80, 50),
    //    ( '2024-04-02', 2, 2, 2, 2, 2, 85, 55),
    //    ( '2024-04-03', 3, 3, 3, 3, 3, 75, 45),
    //    ( '2024-04-04', 1, 1, 1, 1, 1, 90, 60),
    //    ( '2024-04-05', 2, 2, 2, 2, 2, 95, 65),
    //    ( '2024-04-06', 3, 3, 3, 3, 3, 82, 52),
    //    ( '2024-04-07', 1, 1, 1, 1, 1, 88, 58),
    //    ( '2024-04-08', 2, 2, 2, 2, 2, 78, 48),
    //    ( '2024-04-09', 3, 3, 3, 3, 3, 92, 62),
    //    ('2024-04-10', 1, 1, 1, 1, 1, 97, 67) 
    #endregion


    #region Details
    //    INSERT INTO[SchoolSystemDb].[dbo].[StudentMarksDetails]
    //    ([MarkEntryId], [StudentId], [StudentName], [ObtainedScore], [Grade], [PassStatus], [Feedback])
    //VALUES
    //    (1, 1,  'John Doe', 85, 1, 1, 'Excellent performance'),
    //    (2, 2,  'Jane Smith', 78, 2, 2, 'Good effort'),
    //    (3, 3,  'Alice Johnson', 92, 3, 2, 'Outstanding work') 
    #endregion


}
