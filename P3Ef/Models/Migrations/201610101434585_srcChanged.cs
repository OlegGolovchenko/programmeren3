namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class srcChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sources", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sources", "Content", c => c.Binary());
        }
    }
}
