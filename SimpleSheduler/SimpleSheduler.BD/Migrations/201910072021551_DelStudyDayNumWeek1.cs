namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelStudyDayNumWeek1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyDays", "NumberDayOfWeek", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyDays", "NumberDayOfWeek", c => c.String());
        }
    }
}
