using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudentAttendanceSystem.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Attendance
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime AttendanceDate { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public virtual Student.Student Student { get; set; }
        public virtual Course.Course Course { get; set; }
    }
}