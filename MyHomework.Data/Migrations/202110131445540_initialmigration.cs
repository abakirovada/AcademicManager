namespace MyHomework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Deadline = c.DateTimeOffset(nullable: false, precision: 7),
                        ClassId = c.Int(nullable: false),
                        IsAssigned = c.Boolean(nullable: false),
                        IsGraded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Teacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId)
                .Index(t => t.Teacher_TeacherId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                        Student_StudentId1 = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .ForeignKey("dbo.Student", t => t.Student_StudentId1)
                .Index(t => t.ClassId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Student_StudentId1);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        GradeId = c.Int(nullable: false),
                        Enrollment_EnrollmentId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId)
                .Index(t => t.Enrollment_EnrollmentId);
            
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Points = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.AssignmentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Assignment", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Class", "Teacher_TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Student", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.Enrollment", "Student_StudentId1", "dbo.Student");
            DropForeignKey("dbo.Grade", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Grade", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Enrollment", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "ClassId", "dbo.Class");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Grade", new[] { "StudentId" });
            DropIndex("dbo.Grade", new[] { "AssignmentId" });
            DropIndex("dbo.Student", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.Enrollment", new[] { "Student_StudentId1" });
            DropIndex("dbo.Enrollment", new[] { "Student_StudentId" });
            DropIndex("dbo.Enrollment", new[] { "ClassId" });
            DropIndex("dbo.Class", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Assignment", new[] { "ClassId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Teacher");
            DropTable("dbo.Grade");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Class");
            DropTable("dbo.Assignment");
        }
    }
}
