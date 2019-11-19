namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 20),
                        NumberOfSeats = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Curricula",
                c => new
                    {
                        CurriculumId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        TypeOfClassesId = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CurriculumId)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfClasses", t => t.TypeOfClassesId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId)
                .Index(t => t.TypeOfClassesId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 50),
                        NumberOfPersons = c.Int(nullable: false),
                        Seminar = c.String(nullable: false, maxLength: 20),
                        Potok = c.String(nullable: false, maxLength: 20),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 5),
                        FullName = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.TypeOfClasses",
                c => new
                    {
                        TypeOfClassesId = c.Int(nullable: false, identity: true),
                        Abbreviation = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 100),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TypeOfClassesId);
            
            CreateTable(
                "dbo.Pairs",
                c => new
                    {
                        PairId = c.Int(nullable: false, identity: true),
                        NameThePair = c.String(nullable: false, maxLength: 20),
                        NumberThePair = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PairId);
            
            CreateTable(
                "dbo.StudyDays",
                c => new
                    {
                        StudyDayId = c.Int(nullable: false, identity: true),
                        AbbreviationDayOfWeek = c.String(nullable: false, maxLength: 20),
                        FullNameDayOfWeek = c.String(nullable: false, maxLength: 20),
                        NumberDayOfWeek = c.Int(),
                        NumberOfWeek = c.Int(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudyDayId);
            
            CreateTable(
                "dbo.TypeUnionGroups",
                c => new
                    {
                        TypeUnionGroupId = c.Int(nullable: false, identity: true),
                        IsDelete = c.Boolean(nullable: false),
                        Abbreviation = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TypeUnionGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curricula", "TypeOfClassesId", "dbo.TypeOfClasses");
            DropForeignKey("dbo.Curricula", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Curricula", "GroupId", "dbo.Groups");
            DropIndex("dbo.Curricula", new[] { "TypeOfClassesId" });
            DropIndex("dbo.Curricula", new[] { "SubjectId" });
            DropIndex("dbo.Curricula", new[] { "GroupId" });
            DropTable("dbo.TypeUnionGroups");
            DropTable("dbo.StudyDays");
            DropTable("dbo.Pairs");
            DropTable("dbo.TypeOfClasses");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Curricula");
            DropTable("dbo.Classrooms");
        }
    }
}
