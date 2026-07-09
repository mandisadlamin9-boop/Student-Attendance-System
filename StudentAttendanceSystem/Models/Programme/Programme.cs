using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace StudentAttendanceSystem.Models.Programme
{
    public class Programme
    {
        [Key]
        public int ProgrammeId { get; set; }

        [Required]
        [StringLength(20)]
        public string ProgrammeCode { get; set; }

        [Required]
        [StringLength(100)]
        public string ProgrammeName { get; set; }

        [Required]
        public int Duration { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department.Department Department { get; set; }

        public virtual ICollection<Module.Module> Modules { get; set; }

        public Programme()
        {
            Modules = new HashSet<Module.Module>();
        }
    }
}