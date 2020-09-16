namespace GenericRepositoryAndUnitOfWorkMVC5_Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstructorName = c.String(nullable: false, maxLength: 100),
                        Qualification = c.String(nullable: false, maxLength: 100),
                        Experience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 100),
                        CourseFee = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseDuration = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        BatchTime = c.DateTime(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "InstructorId" });
            DropIndex("dbo.Students", new[] { "CourseId" });
            DropTable("dbo.Students");
            DropTable("dbo.Instructors");
            DropTable("dbo.Courses");
        }
    }
}
