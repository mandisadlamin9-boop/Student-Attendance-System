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

        [Required]
        [StringLength(20)]
        public string EmployeeNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public int UserId { get; set; }

        public virtual StudentAttendanceSystem.Models.Account.User User { get; set; }

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; }
    }
}