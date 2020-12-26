namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviscategoryChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_servicecategory", "Description", c => c.String());
            DropColumn("dbo.tbl_servicecategory", "Aciqlama");
            DropColumn("dbo.tbl_servicecategory", "Test1");
            DropColumn("dbo.tbl_servicecategory", "Test2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_servicecategory", "Test2", c => c.String(maxLength: 250));
            AddColumn("dbo.tbl_servicecategory", "Test1", c => c.String(maxLength: 250));
            AddColumn("dbo.tbl_servicecategory", "Aciqlama", c => c.String());
            DropColumn("dbo.tbl_servicecategory", "Description");
        }
    }
}
