namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudyDayRe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudyDays", "NumberDayOfWeek", c => c.String(nullable: false, maxLength: 20));
        }
        



        public override void Down()
        {
            DropColumn("dbo.StudyDays", "NumberDayOfWeek");
        }
    }
}
