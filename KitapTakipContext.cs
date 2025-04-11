using Microsoft.EntityFrameworkCore;
using KitapTakip.Models;

namespace KitapTakip.Data
{
    public class KitapTakipContext : DbContext
    {
        public KitapTakipContext(DbContextOptions<KitapTakipContext> options)
            : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>()
                .Property(k => k.Ad)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Kitap>()
                .Property(k => k.Yazar)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Kitap>()
                .Property(k => k.ISBN)
                .IsRequired();
        }
    }
} 