namespace MarketPlace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Service_To_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        serviceId = c.Int(nullable: false),
                        userId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_services", t => t.serviceId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.ApplicationUser_Id)
                .Index(t => t.serviceId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        registerTime = c.DateTime(),
                        PhotoId = c.Int(nullable: false),
                        Adress = c.String(),
                        isActive = c.Boolean(nullable: false),
                        FullName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_photo", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tbl_photo",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        URL = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.PhotoId);
            
            CreateTable(
                "dbo.tbl_blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Context = c.String(),
                        Views = c.Int(),
                        PublishTime = c.DateTime(),
                        BlogCategoryId = c.Int(),
                        PhotoId = c.Int(),
                        UserId = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Users", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.tbl_blogcategory", t => t.BlogCategoryId)
                .ForeignKey("dbo.tbl_photo", t => t.PhotoId)
                .Index(t => t.BlogCategoryId)
                .Index(t => t.PhotoId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.tbl_blogcategory",
                c => new
                    {
                        BlogCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        Description = c.String(maxLength: 500),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.BlogCategoryId)
                .ForeignKey("dbo.tbl_photo", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.tbl_servicecategory",
                c => new
                    {
                        ServiceCategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 70),
                        Aciqlama = c.String(),
                        Test1 = c.String(maxLength: 250),
                        Test2 = c.String(maxLength: 250),
                        PhotoId = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceCategoryId)
                .ForeignKey("dbo.tbl_photo", t => t.PhotoId)
                .Index(t => t.PhotoId);
            
            CreateTable(
                "dbo.tbl_services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Context = c.String(),
                        ServiceCategoryId = c.Int(),
                        Date = c.DateTime(),
                        Note = c.String(),
                        PhotoId = c.Int(),
                        Baxis = c.Int(),
                        Active = c.Boolean(),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.tbl_photo", t => t.PhotoId)
                .ForeignKey("dbo.tbl_servicecategory", t => t.ServiceCategoryId)
                .Index(t => t.ServiceCategoryId)
                .Index(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Service_To_User", "ApplicationUser_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.tbl_services", "ServiceCategoryId", "dbo.tbl_servicecategory");
            DropForeignKey("dbo.tbl_services", "PhotoId", "dbo.tbl_photo");
            DropForeignKey("dbo.Service_To_User", "serviceId", "dbo.tbl_services");
            DropForeignKey("dbo.tbl_servicecategory", "PhotoId", "dbo.tbl_photo");
            DropForeignKey("dbo.tbl_blog", "PhotoId", "dbo.tbl_photo");
            DropForeignKey("dbo.tbl_blogcategory", "PhotoId", "dbo.tbl_photo");
            DropForeignKey("dbo.tbl_blog", "BlogCategoryId", "dbo.tbl_blogcategory");
            DropForeignKey("dbo.tbl_blog", "ApplicationUser_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "PhotoId", "dbo.tbl_photo");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropIndex("dbo.tbl_services", new[] { "PhotoId" });
            DropIndex("dbo.tbl_services", new[] { "ServiceCategoryId" });
            DropIndex("dbo.tbl_servicecategory", new[] { "PhotoId" });
            DropIndex("dbo.tbl_blogcategory", new[] { "PhotoId" });
            DropIndex("dbo.tbl_blog", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.tbl_blog", new[] { "PhotoId" });
            DropIndex("dbo.tbl_blog", new[] { "BlogCategoryId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "PhotoId" });
            DropIndex("dbo.Service_To_User", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Service_To_User", new[] { "serviceId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropTable("dbo.tbl_services");
            DropTable("dbo.tbl_servicecategory");
            DropTable("dbo.tbl_blogcategory");
            DropTable("dbo.tbl_blog");
            DropTable("dbo.tbl_photo");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Service_To_User");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
        }
    }
}
