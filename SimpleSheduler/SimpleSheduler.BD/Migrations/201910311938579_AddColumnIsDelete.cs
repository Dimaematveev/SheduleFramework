namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnIsDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Curricula", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pairs", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.StudyDays", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudyDays", "IsDelete");
            DropColumn("dbo.Pairs", "IsDelete");
            DropColumn("dbo.Subjects", "IsDelete");
            DropColumn("dbo.Groups", "IsDelete");
            DropColumn("dbo.Curricula", "IsDelete");
            DropColumn("dbo.Classrooms", "IsDelete");
        }
    }
}
