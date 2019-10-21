namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newBD : DbMigration
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
                        NumberOfLectures = c.Int(nullable: false),
                        NumberOfPractical = c.Int(nullable: false),
                        NumberOfLaboratory = c.Int(nullable: false),
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
                        Name = c.String(nullable: false, maxLength: 50),
                        NumberOfPersons = c.Int(nullable: false),
                        Seminar = c.String(nullable: false, maxLength: 20),
                        Potok = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Pairs",
                c => new
                    {
                        PairId = c.Int(nullable: false, identity: true),
                        NameThePair = c.String(nullable: false, maxLength: 20),
                        NumberThePair = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PairId);
            
            CreateTable(
                "dbo.StudyDays",
                c => new
                    {
                        StudyDayId = c.Int(nullable: false, identity: true),
                        NameDayOfWeek = c.String(nullable: false, maxLength: 20),
                        NumberDayOfWeek = c.Int(),
                        NumberOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudyDayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curricula", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Curricula", "GroupId", "dbo.Groups");
            DropIndex("dbo.Curricula", new[] { "SubjectId" });
            DropIndex("dbo.Curricula", new[] { "GroupId" });
            DropTable("dbo.StudyDays");
            DropTable("dbo.Pairs");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Curricula");
            DropTable("dbo.Classrooms");
        }
    }
}
