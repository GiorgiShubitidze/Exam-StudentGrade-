namespace StudentGrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Point = c.Int(nullable: false),
                        StudentCsvId = c.Int(nullable: false),
                        SubjectCsvId = c.Int(nullable: false),
                        PointCsv = c.Int(nullable: false),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Subject_SubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGrades", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Students", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentGrades", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "Subject_SubjectId" });
            DropIndex("dbo.StudentGrades", new[] { "SubjectId" });
            DropIndex("dbo.StudentGrades", new[] { "StudentId" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.StudentGrades");
        }
    }
}
