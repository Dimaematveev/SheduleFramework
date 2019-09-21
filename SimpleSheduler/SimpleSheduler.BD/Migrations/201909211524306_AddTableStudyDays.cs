namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableStudyDays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudyDays",
                c => new
                    {
                        StudyDayId = c.Int(nullable: false, identity: true),
                        NameDayOfWeek = c.String(nullable: false, maxLength: 20),
                        NumberOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudyDayId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudyDays");
        }
    }
}
