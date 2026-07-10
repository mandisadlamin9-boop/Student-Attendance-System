using System.Data.Entity;
using StudentAttendanceSystem.Models.Account;
using StudentAttendanceSystem.Models.AcademicYear;
using StudentAttendanceSystem.Models.Attendance;
using StudentAttendanceSystem.Models.AttendanceSession;
using StudentAttendanceSystem.Models.Department;
using StudentAttendanceSystem.Models.Enrollment;
using StudentAttendanceSystem.Models.Faculty;
using StudentAttendanceSystem.Models.Lecturer;
using StudentAttendanceSystem.Models.Module;
using StudentAttendanceSystem.Models.Programme;
using StudentAttendanceSystem.Models.Semester;
using StudentAttendanceSystem.Models.Student;
using StudentAttendanceSystem.Models.TeachingAssignment;

namespace StudentAttendanceSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StudentAttendanceDB")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
        public DbSet<AttendanceSession> AttendanceSessions { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Programme>()
                .HasRequired(p => p.Department)
                .WithMany(d => d.Programmes)
                .HasForeignKey(p => p.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Module>()
                .HasRequired(m => m.Programme)
                .WithMany(p => p.Modules)
                .HasForeignKey(m => m.ProgrammeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lecturer>()
                .HasRequired(l => l.Department)
                .WithMany(d => d.Lecturers)
                .HasForeignKey(l => l.DepartmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Programme)
                .WithMany()
                .HasForeignKey(e => e.ProgrammeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.AcademicYear)
                .WithMany(a => a.Enrollments)
                .HasForeignKey(e => e.AcademicYearId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enrollment>()
                .HasRequired(e => e.Semester)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.SemesterId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TeachingAssignment>()
    .HasRequired(t => t.Lecturer)
    .WithMany(l => l.TeachingAssignments)
    .HasForeignKey(t => t.LecturerId)
    .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeachingAssignment>()
                .HasRequired(t => t.Module)
                .WithMany(m => m.TeachingAssignments)
                .HasForeignKey(t => t.ModuleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeachingAssignment>()
                .HasRequired(t => t.AcademicYear)
                .WithMany()
                .HasForeignKey(t => t.AcademicYearId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TeachingAssignment>()
                .HasRequired(t => t.Semester)
                .WithMany()
                .HasForeignKey(t => t.SemesterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.AttendanceSession)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.AttendanceSessionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AttendanceSession>()
                .HasRequired(a => a.TeachingAssignment)
                .WithMany()
                .HasForeignKey(a => a.TeachingAssignmentId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}