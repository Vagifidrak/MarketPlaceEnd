namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_blogcategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_blogcategory()
        {
            tbl_blog = new HashSet<tbl_blog>();
        }

        [Key]
        public int BlogCategoryId { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? PhotoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_blog> tbl_blog { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }
    }
}
