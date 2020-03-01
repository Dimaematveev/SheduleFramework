namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteIsDelete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Classrooms", "IsDelete");
            DropColumn("dbo.Curricula", "IsDelete");
            DropColumn("dbo.Groups", "IsDelete");
            DropColumn("dbo.Subjects", "IsDelete");
            DropColumn("dbo.TypeOfClasses", "IsDelete");
            DropColumn("dbo.Pairs", "IsDelete");
            DropColumn("dbo.StudyDays", "IsDelete");
            DropColumn("dbo.TypeUnionGroups", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TypeUnionGroups", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.StudyDays", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pairs", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.TypeOfClasses", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Subjects", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Groups", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Curricula", "IsDelete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Classrooms", "IsDelete", c => c.Boolean(nullable: false));
        }
    }
}
