using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Lecturer
{
    public class Lecturer
    {
        [Key]
        public int LecturerId { get; set; }

        public int UserId { get; set; }

        public int DepartmentId { get; set; }

        [Required]
        [StringLength(20)]
        public string EmployeeNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public virtual Account.User User { get; set; }

        public virtual Department.Department Department { get; set; }

        public virtual ICollection<TeachingAssignment.TeachingAssignment> TeachingAssignments { get; set; }

        public Lecturer()
        {
            TeachingAssignments = new HashSet<TeachingAssignment.TeachingAssignment>();
        }
    }
}