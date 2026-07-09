using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Faculty
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        [StringLength(100)]
        public string FacultyName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        // Navigation Property
        public virtual ICollection<Department.Department> Departments { get; set; }

        public Faculty()
        {
            Departments = new HashSet<Department.Department>();
        }
    }
}