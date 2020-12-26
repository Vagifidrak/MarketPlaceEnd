namespace MarketPlace.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=marketplaceDB")
        {
        }

        public virtual DbSet<tbl_blog> tbl_blog { get; set; }
        public virtual DbSet<tbl_blogcategory> tbl_blogcategory { get; set; }
        public virtual DbSet<tbl_photo> tbl_photo { get; set; }
        public virtual DbSet<tbl_servicecategory> tbl_servicecategory { get; set; }
        public virtual DbSet<tbl_serviceprovider> tbl_serviceprovider { get; set; }
        public virtual DbSet<tbl_services> tbl_services { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_services)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.CustomerId);
        }
    }
}
