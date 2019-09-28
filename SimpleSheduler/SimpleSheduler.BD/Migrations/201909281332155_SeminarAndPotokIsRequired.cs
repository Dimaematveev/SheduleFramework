namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeminarAndPotokIsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Groups", "Seminar", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Groups", "Potok", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Groups", "Potok", c => c.String(maxLength: 20));
            AlterColumn("dbo.Groups", "Seminar", c => c.String(maxLength: 20));
        }
    }
}
