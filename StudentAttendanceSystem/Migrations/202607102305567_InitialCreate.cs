namespace StudentAttendanceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicYears",
                c => new
                    {
                        AcademicYearId = c.Int(nullable: false, identity: true),
                        Year = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.AcademicYearId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        ProgrammeId = c.Int(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Programmes", t => t.ProgrammeId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.ProgrammeId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Programmes",
                c => new
                    {
                        ProgrammeId = c.Int(nullable: false, identity: true),
                        ProgrammeCode = c.String(nullable: false, maxLength: 20),
                        ProgrammeName = c.String(nullable: false, maxLength: 100),
                        Duration = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgrammeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Lecturers",
                c => new
                    {
                        LecturerId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        EmployeeNumber = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.LecturerId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.TeachingAssignments",
                c => new
                    {
                        TeachingAssignmentId = c.Int(nullable: false, identity: true),
                        LecturerId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        AcademicYearId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeachingAssignmentId)
                .ForeignKey("dbo.AcademicYears", t => t.AcademicYearId)
                .ForeignKey("dbo.Lecturers", t => t.LecturerId)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .Index(t => t.LecturerId)
                .Index(t => t.ModuleId)
                .Index(t => t.AcademicYearId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleCode = c.String(nullable: false, maxLength: 20),
                        ModuleName = c.String(nullable: false, maxLength: 100),
                        Credits = c.Int(nullable: false),
                        ProgrammeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Programmes", t => t.ProgrammeId)
                .Index(t => t.ProgrammeId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        Role = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentNumber = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        AttendanceSessionId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        TimeMarked = c.DateTime(nullable: false),
                        Remarks = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AttendanceSessions", t => t.AttendanceSessionId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.AttendanceSessionId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.AttendanceSessions",
                c => new
                    {
                        AttendanceSessionId = c.Int(nullable: false, identity: true),
                        TeachingAssignmentId = c.Int(nullable: false),
                        SessionDate = c.DateTime(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Venue = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.AttendanceSessionId)
                .ForeignKey("dbo.TeachingAssignments", t => t.TeachingAssignmentId)
                .Index(t => t.TeachingAssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "AttendanceSessionId", "dbo.AttendanceSessions");
            DropForeignKey("dbo.AttendanceSessions", "TeachingAssignmentId", "dbo.TeachingAssignments");
            DropForeignKey("dbo.Enrollments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Enrollments", "ProgrammeId", "dbo.Programmes");
            DropForeignKey("dbo.Programmes", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Lecturers", "UserId", "dbo.Users");
            DropForeignKey("dbo.TeachingAssignments", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.TeachingAssignments", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.Modules", "ProgrammeId", "dbo.Programmes");
            DropForeignKey("dbo.TeachingAssignments", "LecturerId", "dbo.Lecturers");
            DropForeignKey("dbo.TeachingAssignments", "AcademicYearId", "dbo.AcademicYears");
            DropForeignKey("dbo.Lecturers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.Enrollments", "AcademicYearId", "dbo.AcademicYears");
            DropIndex("dbo.AttendanceSessions", new[] { "TeachingAssignmentId" });
            DropIndex("dbo.Attendances", new[] { "StudentId" });
            DropIndex("dbo.Attendances", new[] { "AttendanceSessionId" });
            DropIndex("dbo.Modules", new[] { "ProgrammeId" });
            DropIndex("dbo.TeachingAssignments", new[] { "SemesterId" });
            DropIndex("dbo.TeachingAssignments", new[] { "AcademicYearId" });
            DropIndex("dbo.TeachingAssignments", new[] { "ModuleId" });
            DropIndex("dbo.TeachingAssignments", new[] { "LecturerId" });
            DropIndex("dbo.Lecturers", new[] { "DepartmentId" });
            DropIndex("dbo.Lecturers", new[] { "UserId" });
            DropIndex("dbo.Departments", new[] { "FacultyId" });
            DropIndex("dbo.Programmes", new[] { "DepartmentId" });
            DropIndex("dbo.Enrollments", new[] { "SemesterId" });
            DropIndex("dbo.Enrollments", new[] { "AcademicYearId" });
            DropIndex("dbo.Enrollments", new[] { "ProgrammeId" });
            DropIndex("dbo.Enrollments", new[] { "StudentId" });
            DropTable("dbo.AttendanceSessions");
            DropTable("dbo.Attendances");
            DropTable("dbo.Students");
            DropTable("dbo.Users");
            DropTable("dbo.Semesters");
            DropTable("dbo.Modules");
            DropTable("dbo.TeachingAssignments");
            DropTable("dbo.Lecturers");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
            DropTable("dbo.Programmes");
            DropTable("dbo.Enrollments");
            DropTable("dbo.AcademicYears");
        }
    }
}
