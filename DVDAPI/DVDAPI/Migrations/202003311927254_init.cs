namespace DVDAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false, maxLength: 50),
                        year = c.Int(nullable: false),
                        director = c.String(nullable: false, maxLength: 50),
                        rating = c.String(nullable: false, maxLength:50),
                        notes = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DVDs");
        }
    }
}
