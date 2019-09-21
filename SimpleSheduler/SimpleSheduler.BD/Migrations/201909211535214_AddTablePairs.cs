namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePairs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pairs",
                c => new
                    {
                        PairId = c.Int(nullable: false, identity: true),
                        NameThePair = c.String(nullable: false, maxLength: 20),
                        NumberThePair = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PairId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pairs");
        }
    }
}
