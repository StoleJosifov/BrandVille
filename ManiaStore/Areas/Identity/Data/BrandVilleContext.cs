using BrandVille.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrandVille.Areas.Identity.Data
{
    public class BrandVilleContext : IdentityDbContext<BrandVilleUser>
    {
        public BrandVilleContext(DbContextOptions<BrandVilleContext> options)
            : base(options)
        {

        }

        public DbSet<BasketItems> BasketItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
