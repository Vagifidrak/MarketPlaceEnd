namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_servicecategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_servicecategory()
        {
            tbl_serviceprovider = new HashSet<tbl_serviceprovider>();
            tbl_services = new HashSet<tbl_services>();
        }

        [Key]
        public int ServiceCategoryId { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public string Aciqlama { get; set; }

        [StringLength(250)]
        public string Test1 { get; set; }

        [StringLength(250)]
        public string Test2 { get; set; }

        public int? PhotoId { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_serviceprovider> tbl_serviceprovider { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_services> tbl_services { get; set; }
    }
}
