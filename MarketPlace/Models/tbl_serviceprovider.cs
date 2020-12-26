namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_serviceprovider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_serviceprovider()
        {
            tbl_services = new HashSet<tbl_services>();
        }

        [Key]
        public int ServiceProviderId { get; set; }

        [StringLength(60)]
        public string Ad { get; set; }

        [StringLength(60)]
        public string Soyad { get; set; }

        [StringLength(70)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Sifre { get; set; }

        public string Vaxtlar { get; set; }

        public int? Nomre { get; set; }

        public int? ServiceCategoryId { get; set; }

        [StringLength(350)]
        public string Unvan { get; set; }

        public int? PhotoId { get; set; }

        public virtual tbl_servicecategory tbl_servicecategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_services> tbl_services { get; set; }
    }
}
