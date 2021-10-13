namespace MyHomework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDataChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollment", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Enrollment", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "Student_StudentId1", "dbo.Student");
            DropForeignKey("dbo.Student", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropIndex("dbo.Enrollment", new[] { "ClassId" });
            DropIndex("dbo.Enrollment", new[] { "Student_StudentId" });
            DropIndex("dbo.Enrollment", new[] { "Student_StudentId1" });
            DropIndex("dbo.Student", new[] { "Enrollment_EnrollmentId" });
            CreateTable(
                "dbo.EnrollmentClass",
                c => new
                    {
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                        Class_ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Enrollment_EnrollmentId, t.Class_ClassId })
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.Class", t => t.Class_ClassId, cascadeDelete: true)
                .Index(t => t.Enrollment_EnrollmentId)
                .Index(t => t.Class_ClassId);
            
            CreateTable(
                "dbo.StudentEnrollment",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Enrollment_EnrollmentId })
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Enrollment_EnrollmentId);
            
            AddColumn("dbo.Assignment", "Student_StudentId", c => c.Int());
            AddColumn("dbo.Student", "EnrollmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Student", "AssignmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Assignment", "Student_StudentId");
            AddForeignKey("dbo.Assignment", "Student_StudentId", "dbo.Student", "StudentId");
            DropColumn("dbo.Enrollment", "Student_StudentId");
            DropColumn("dbo.Enrollment", "Student_StudentId1");
            DropColumn("dbo.Student", "Enrollment_EnrollmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Enrollment_EnrollmentId", c => c.Int());
            AddColumn("dbo.Enrollment", "Student_StudentId1", c => c.Int());
            AddColumn("dbo.Enrollment", "Student_StudentId", c => c.Int());
            DropForeignKey("dbo.StudentEnrollment", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.StudentEnrollment", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Assignment", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.EnrollmentClass", "Class_ClassId", "dbo.Class");
            DropForeignKey("dbo.EnrollmentClass", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropIndex("dbo.StudentEnrollment", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.StudentEnrollment", new[] { "Student_StudentId" });
            DropIndex("dbo.EnrollmentClass", new[] { "Class_ClassId" });
            DropIndex("dbo.EnrollmentClass", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.Assignment", new[] { "Student_StudentId" });
            DropColumn("dbo.Student", "AssignmentId");
            DropColumn("dbo.Student", "EnrollmentId");
            DropColumn("dbo.Assignment", "Student_StudentId");
            DropTable("dbo.StudentEnrollment");
            DropTable("dbo.EnrollmentClass");
            CreateIndex("dbo.Student", "Enrollment_EnrollmentId");
            CreateIndex("dbo.Enrollment", "Student_StudentId1");
            CreateIndex("dbo.Enrollment", "Student_StudentId");
            CreateIndex("dbo.Enrollment", "ClassId");
            AddForeignKey("dbo.Student", "Enrollment_EnrollmentId", "dbo.Enrollment", "EnrollmentId");
            AddForeignKey("dbo.Enrollment", "Student_StudentId1", "dbo.Student", "StudentId");
            AddForeignKey("dbo.Enrollment", "Student_StudentId", "dbo.Student", "StudentId");
            AddForeignKey("dbo.Enrollment", "ClassId", "dbo.Class", "ClassId", cascadeDelete: true);
        }
    }
}
