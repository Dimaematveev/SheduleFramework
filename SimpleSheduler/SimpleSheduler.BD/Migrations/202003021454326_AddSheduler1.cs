namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSheduler1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shedulers",
                c => new
                    {
                        ShedulerId = c.Int(nullable: false, identity: true),
                        NumberWeek = c.Int(nullable: false),
                        DayWeek = c.String(nullable: false, maxLength: 20),
                        NumberPair = c.Int(nullable: false),
                        ClassroomId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShedulerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shedulers");
        }
    }
}
