namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "FullName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Groups", "FullName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Subjects", "FullName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.StudyDays", "FullNameDayOfWeek", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudyDays", "FullNameDayOfWeek");
            DropColumn("dbo.Subjects", "FullName");
            DropColumn("dbo.Groups", "FullName");
            DropColumn("dbo.Classrooms", "FullName");
        }
    }
}
