using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.AcademicYear
{
    public class AcademicYear
    {
        [Key]
        public int AcademicYearId { get; set; }

        [Required]
        [StringLength(9)]
        public string Year { get; set; }

        public virtual ICollection<Enrollment.Enrollment> Enrollments { get; set; }

        public AcademicYear()
        {
            Enrollments = new HashSet<Enrollment.Enrollment>();
        }
    }
}