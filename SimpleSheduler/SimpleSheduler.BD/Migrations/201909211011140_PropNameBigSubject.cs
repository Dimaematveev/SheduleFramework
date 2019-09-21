namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropNameBigSubject : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
