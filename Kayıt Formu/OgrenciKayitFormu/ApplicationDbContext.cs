// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using OgrenciKayitFormu.Models;

namespace OgrenciKayitFormu.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenciler { get; set; }
    }
}