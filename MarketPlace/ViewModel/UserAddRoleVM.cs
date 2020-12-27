using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.ViewModel
{
    public class UserAddRoleVM
    {
        public ApplicationUser AppUser { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}