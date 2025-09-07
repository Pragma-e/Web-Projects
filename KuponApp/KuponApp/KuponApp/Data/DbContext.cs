using Microsoft.EntityFrameworkCore;
using KuponApp.Models;

namespace KuponApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
