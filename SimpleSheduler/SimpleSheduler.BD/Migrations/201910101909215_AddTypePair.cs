namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypePair : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypePairs",
                c => new
                    {
                        TypePairId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.TypePairId);
            
            AddColumn("dbo.Curricula", "TypePairId", c => c.Int(nullable: false));
            CreateIndex("dbo.Curricula", "TypePairId");
            AddForeignKey("dbo.Curricula", "TypePairId", "dbo.TypePairs", "TypePairId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curricula", "TypePairId", "dbo.TypePairs");
            DropIndex("dbo.Curricula", new[] { "TypePairId" });
            DropColumn("dbo.Curricula", "TypePairId");
            DropTable("dbo.TypePairs");
        }
    }
}
