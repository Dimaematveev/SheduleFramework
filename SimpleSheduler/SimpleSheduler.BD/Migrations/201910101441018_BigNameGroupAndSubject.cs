namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigNameGroupAndSubject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
