namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Project1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sources", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Sources", new[] { "Project_Id" });
            AddColumn("dbo.Sources", "PName", c => c.String());
            DropColumn("dbo.Sources", "Project_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sources", "Project_Id", c => c.Int());
            DropColumn("dbo.Sources", "PName");
            CreateIndex("dbo.Sources", "Project_Id");
            AddForeignKey("dbo.Sources", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
