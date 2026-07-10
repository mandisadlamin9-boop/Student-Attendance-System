using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Student
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(20)]
        public string StudentNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Enrollment.Enrollment> Enrollments { get; set; }

        public virtual ICollection<Attendance.Attendance> Attendances { get; set; }

        public Student()
        {
            Enrollments = new HashSet<Enrollment.Enrollment>();
            Attendances = new HashSet<Attendance.Attendance>();
        }
    }
}