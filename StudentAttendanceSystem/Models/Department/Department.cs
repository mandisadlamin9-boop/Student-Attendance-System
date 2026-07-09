using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Department
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int FacultyId { get; set; }

        public virtual Faculty.Faculty Faculty { get; set; }

        // Navigation Properties
        public virtual ICollection<Programme.Programme> Programmes { get; set; }
        public virtual ICollection<Lecturer.Lecturer> Lecturers { get; set; }

        public Department()
        {
            Programmes = new HashSet<Programme.Programme>();
            Lecturers = new HashSet<Lecturer.Lecturer>();
        }
    }
}