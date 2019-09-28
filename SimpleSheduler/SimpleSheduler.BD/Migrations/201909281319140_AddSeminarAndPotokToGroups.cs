namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeminarAndPotokToGroups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Seminar", c => c.String(maxLength: 20));
            AddColumn("dbo.Groups", "Potok", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "Potok");
            DropColumn("dbo.Groups", "Seminar");
        }
    }
}
