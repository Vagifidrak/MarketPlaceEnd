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

        public int? Price { get; set; }

        public string Context { get; set; }

        public int? ServiceCategoryId { get; set; }

        public int? ServiceProviderId { get; set; }

        public int? CustomerId { get; set; }

        public DateTime? Date { get; set; }

        public int? GunerzindeSaat { get; set; }

        public string Note { get; set; }

        public int? PhotoId { get; set; }

        public int? Baxis { get; set; }

        [StringLength(500)]
        public string Aciqlama { get; set; }

        [StringLength(500)]
        public string Xidmetler { get; set; }

        public bool? Aktiv { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        public virtual tbl_servicecategory tbl_servicecategory { get; set; }

        public virtual tbl_serviceprovider tbl_serviceprovider { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
