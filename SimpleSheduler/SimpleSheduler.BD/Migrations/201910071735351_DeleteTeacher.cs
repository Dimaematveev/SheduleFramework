namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubjectOfTeachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectOfTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.SubjectOfTeachers", new[] { "SubjectId" });
            DropIndex("dbo.SubjectOfTeachers", new[] { "TeacherId" });
            DropTable("dbo.SubjectOfTeachers");
            DropTable("dbo.Teachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.SubjectOfTeachers",
                c => new
                    {
                        SubjectOfTeacherId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectOfTeacherId);
            
            CreateIndex("dbo.SubjectOfTeachers", "TeacherId");
            CreateIndex("dbo.SubjectOfTeachers", "SubjectId");
            AddForeignKey("dbo.SubjectOfTeachers", "TeacherId", "dbo.Teachers", "TeacherId", cascadeDelete: true);
            AddForeignKey("dbo.SubjectOfTeachers", "SubjectId", "dbo.Subjects", "SubjectId", cascadeDelete: true);
        }
    }
}
