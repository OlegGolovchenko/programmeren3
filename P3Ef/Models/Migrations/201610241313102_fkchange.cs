namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Lang_Id", "dbo.Languages");
            DropIndex("dbo.Projects", new[] { "Lang_Id" });
            RenameColumn(table: "dbo.Projects", name: "Lang_Id", newName: "LangId");
            AlterColumn("dbo.Projects", "LangId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "LangId");
            AddForeignKey("dbo.Projects", "LangId", "dbo.Languages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "LangId", "dbo.Languages");
            DropIndex("dbo.Projects", new[] { "LangId" });
            AlterColumn("dbo.Projects", "LangId", c => c.Int());
            RenameColumn(table: "dbo.Projects", name: "LangId", newName: "Lang_Id");
            CreateIndex("dbo.Projects", "Lang_Id");
            AddForeignKey("dbo.Projects", "Lang_Id", "dbo.Languages", "Id");
        }
    }
}
