namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        NumberOfSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Curricula",
                c => new
                    {
                        CurriculumId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        NumberOfPairs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CurriculumId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        NumberOfPersons = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectOfTeachers",
                c => new
                    {
                        SubjectOfTeacherId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectOfTeacherId)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubjectOfTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.SubjectOfTeachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Curricula", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Curricula", "GroupId", "dbo.Groups");
            DropIndex("dbo.SubjectOfTeachers", new[] { "SubjectId" });
            DropIndex("dbo.SubjectOfTeachers", new[] { "TeacherId" });
            DropIndex("dbo.Curricula", new[] { "SubjectId" });
            DropIndex("dbo.Curricula", new[] { "GroupId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.SubjectOfTeachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Curricula");
            DropTable("dbo.Classrooms");
        }
    }
}
