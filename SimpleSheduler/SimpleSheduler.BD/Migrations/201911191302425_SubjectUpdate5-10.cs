namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectUpdate510 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Abbreviation", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Abbreviation", c => c.String(nullable: false, maxLength: 5));
        }
    }
}
