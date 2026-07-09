using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Semester
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }

        [Required]
        [StringLength(20)]
        public string SemesterName { get; set; }

        public virtual ICollection<Enrollment.Enrollment> Enrollments { get; set; }

        public Semester()
        {
            Enrollments = new HashSet<Enrollment.Enrollment>();
        }
    }
}