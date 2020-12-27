namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Service_To_User", "userId", c => c.String());
            AlterColumn("dbo.tbl_blog", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_blog", "UserId", c => c.Int());
            AlterColumn("dbo.Service_To_User", "userId", c => c.Int(nullable: false));
        }
    }
}
