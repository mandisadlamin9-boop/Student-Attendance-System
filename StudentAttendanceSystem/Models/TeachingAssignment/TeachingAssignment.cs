using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.TeachingAssignment
{
    public class TeachingAssignment
    {
        [Key]
        public int TeachingAssignmentId { get; set; }

        public int LecturerId { get; set; }

        public int ModuleId { get; set; }

        public int AcademicYearId { get; set; }

        public int SemesterId { get; set; }

        public virtual Lecturer.Lecturer Lecturer { get; set; }

        public virtual Module.Module Module { get; set; }

        public virtual AcademicYear.AcademicYear AcademicYear { get; set; }

        public virtual Semester.Semester Semester { get; set; }
    }
}