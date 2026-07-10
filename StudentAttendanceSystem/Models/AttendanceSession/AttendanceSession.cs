using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.AttendanceSession
{
    public class AttendanceSession
    {
        [Key]
        public int AttendanceSessionId { get; set; }

        public int TeachingAssignmentId { get; set; }

        [Required]
        public DateTime SessionDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        [StringLength(100)]
        public string Venue { get; set; }

        public virtual TeachingAssignment.TeachingAssignment TeachingAssignment { get; set; }

        public virtual ICollection<Attendance.Attendance> Attendances { get; set; }

        public AttendanceSession()
        {
            Attendances = new HashSet<Attendance.Attendance>();
        }
    }
}