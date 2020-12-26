namespace MarketPlace.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_blog
    {
        [Key]
        public int BlogId { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        public string Context { get; set; }

        public int? Views { get; set; }

        public DateTime? PublishTime { get; set; }

        public int? BlogCategoryId { get; set; }

        public int? PhotoId { get; set; }

        public int? UserId { get; set; }

        public virtual tbl_blogcategory tbl_blogcategory { get; set; }

        public virtual tbl_photo tbl_photo { get; set; }

        public virtual tbl_user tbl_user { get; set; }
    }
}
