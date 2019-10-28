namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFullName1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "FullName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "FullName", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
