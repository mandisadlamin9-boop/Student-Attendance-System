using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentAttendanceSystem.Models.Module
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        [StringLength(20)]
        public string ModuleCode { get; set; }

        [Required]
        [StringLength(100)]
        public string ModuleName { get; set; }

        public int Credits { get; set; }

        public int ProgrammeId { get; set; }

        public virtual Programme.Programme Programme { get; set; }

        public virtual ICollection<TeachingAssignment.TeachingAssignment> TeachingAssignments { get; set; }

        public Module()
        {
            TeachingAssignments = new HashSet<TeachingAssignment.TeachingAssignment>();
        }
    }
}