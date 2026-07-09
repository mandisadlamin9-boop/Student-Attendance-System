using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using StudentAttendanceSystem.Utilities.Enums;

namespace StudentAttendanceSystem.Models.Account
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get;set; }

        [Required]
        [StringLength(20)]
        public UserRole Role { get; set; }

        public bool IsActive { get; set; }
    }

}