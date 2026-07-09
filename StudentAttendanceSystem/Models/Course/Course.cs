using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Course
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(20)]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

       
        public int LecturerId { get; set; }

        public virtual Lecturer.Lecturer Lecturer { get; set; }

       
        public virtual ICollection<Student.Student> Students { get; set; }
    }
}