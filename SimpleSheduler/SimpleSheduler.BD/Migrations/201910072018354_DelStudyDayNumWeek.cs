namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStudyDayNumWeek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyDays", "NumberDayOfWeek", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyDays", "NumberDayOfWeek", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
