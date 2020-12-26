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
            tbl_services = new HashSet<tbl_services>();
        }

        [Key]
        public int ServiceCategoryId { get; set; }

        [StringLength(70)]
        public string Name { get; set; }

        public string Description { get; set; }

        

        public int? PhotoId { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_services> tbl_services { get; set; }
    }
}
