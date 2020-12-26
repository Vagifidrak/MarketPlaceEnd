namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "PhotoId", "dbo.tbl_photo");
            DropIndex("dbo.Users", new[] { "PhotoId" });
            AlterColumn("dbo.Users", "PhotoId", c => c.Int());
            AlterColumn("dbo.Users", "isActive", c => c.Boolean());
            CreateIndex("dbo.Users", "PhotoId");
            AddForeignKey("dbo.Users", "PhotoId", "dbo.tbl_photo", "PhotoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PhotoId", "dbo.tbl_photo");
            DropIndex("dbo.Users", new[] { "PhotoId" });
            AlterColumn("dbo.Users", "isActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "PhotoId");
            AddForeignKey("dbo.Users", "PhotoId", "dbo.tbl_photo", "PhotoId", cascadeDelete: true);
        }
    }
}
