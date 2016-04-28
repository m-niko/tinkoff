namespace Tinkoff.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shortens",
                c => new
                    {
                        ShortenId = c.Int(nullable: false, identity: true),
                        RawUrl = c.String(),
                        Url = c.String(),
                        ShortedUrl = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        TotalClicks = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShortenId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shortens");
        }
    }
}
