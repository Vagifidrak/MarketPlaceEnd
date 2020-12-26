using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public partial class Service_To_User
    {
        public int Id { get; set; }
        public int serviceId { get; set; }  
        public int userId { get; set; } 
        public virtual tbl_services Services { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}