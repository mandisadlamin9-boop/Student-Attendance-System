using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Enrollment
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }

        public int ProgrammeId { get; set; }

        public int AcademicYearId { get; set; }

        public int SemesterId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public virtual Student.Student Student { get; set; }

        public virtual Programme.Programme Programme { get; set; }

        public virtual AcademicYear.AcademicYear AcademicYear { get; set; }

        public virtual Semester.Semester Semester { get; set; }
    }
}