using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManiaStore.Models;
using Microsoft.AspNetCore.Identity;

namespace BrandVille.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BrandVilleUser class
    public class BrandVilleUser : IdentityUser
    {
        public List<Product> BasketItems { get; set; }
    }
}
