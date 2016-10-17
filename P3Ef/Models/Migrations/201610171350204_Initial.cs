namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UId = c.String(),
                        Name = c.String(),
                        Lang_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.Lang_Id)
                .Index(t => t.Lang_Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Package = c.String(),
                        Content = c.String(),
                        PName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Lang_Id", "dbo.Languages");
            DropIndex("dbo.Projects", new[] { "Lang_Id" });
            DropTable("dbo.Sources");
            DropTable("dbo.Languages");
            DropTable("dbo.Projects");
        }
    }
}
