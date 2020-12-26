namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_services
    {
        [Key]
        public int ServiceId { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string Context { get; set; }

        public int? ServiceCategoryId { get; set; }

        public DateTime? Date { get; set; }

        public string Note { get; set; }

        public int? PhotoId { get; set; }

        public int? Baxis { get; set; }

        public bool? Active { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        public virtual tbl_servicecategory tbl_servicecategory { get; set; }
        public virtual ICollection<Service_To_User> ServiceToUsers { get; set; }

    }
}
