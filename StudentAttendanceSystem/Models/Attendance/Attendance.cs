using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StudentAttendanceSystem.Utilities.Enums;

namespace StudentAttendanceSystem.Models.Attendance
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        public int AttendanceSessionId { get; set; }

        public int StudentId { get; set; }

        [Required]
        public AttendanceStatus Status { get; set; }

        public DateTime TimeMarked { get; set; }

        [StringLength(250)]
        public string Remarks { get; set; }

        public virtual AttendanceSession.AttendanceSession AttendanceSession { get; set; }

        public virtual Student.Student Student { get; set; }
    }
}