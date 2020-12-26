namespace MarketPlace.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public DateTime? registerTime{ get; set; }
        public int? PhotoId { get; set; }
        public virtual tbl_photo Photo { get; set; }
        public string Adress { get; set; }
        public bool? isActive { get; set; }
        public string FullName { get; set; }
        public virtual List<Service_To_User> ServiceToUsers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public partial class Model1 : IdentityDbContext<ApplicationUser>
    {
      
        public Model1()
            : base("name=marketplaceDB")
        {
        }

        public virtual DbSet<tbl_blog> tbl_blog { get; set; }
        public virtual DbSet<tbl_blogcategory> tbl_blogcategory { get; set; }
        public virtual DbSet<tbl_photo> tbl_photo { get; set; }
        public virtual DbSet<tbl_servicecategory> tbl_servicecategory { get; set; }
        public virtual DbSet<Service_To_User> Service_To_User{ get; set; }
        public virtual DbSet<tbl_services> tbl_services { get; set; }


        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
            dbModelBuilder.Entity<ApplicationUser>().ToTable("Users");
            dbModelBuilder.Entity<IdentityRole>().ToTable("Roles");
            dbModelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            dbModelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            dbModelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

        }
        public static Model1 Create()
        {
            return new Model1();
        }
    }
}
