namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_user()
        {
            tbl_blog = new HashSet<tbl_blog>();
            tbl_services = new HashSet<tbl_services>();
        }

        [Key]
        public int UserId { get; set; }

        [StringLength(60)]
        public string Ad { get; set; }

        [StringLength(60)]
        public string Soyad { get; set; }

        [StringLength(70)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(500)]
        public string Sifre { get; set; }

        public DateTime? QeydiyyatTarixi { get; set; }

        public int? Photo { get; set; }

        public bool? Customor { get; set; }

        public bool? Aktiv { get; set; }

        public bool? QebulEdildi { get; set; }

        public string Haqqinda { get; set; }

        public int? PhotoId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_blog> tbl_blog { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_services> tbl_services { get; set; }
    }
}
