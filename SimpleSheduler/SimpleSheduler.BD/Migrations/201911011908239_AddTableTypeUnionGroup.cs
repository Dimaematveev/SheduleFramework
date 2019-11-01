namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableTypeUnionGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeUnionGroups",
                c => new
                    {
                        TypeUnionGroupId = c.Int(nullable: false, identity: true),
                        IsDelete = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        FullName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.TypeUnionGroupId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeUnionGroups");
        }
    }
}
