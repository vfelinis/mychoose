using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChoose.Models
{
    public class GiftContext : DbContext
    {
        public GiftContext(DbContextOptions<GiftContext> options)
            : base(options) { }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gift> Gifts { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>()
                .HasIndex(p => p.Value).IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName).IsUnique();

            modelBuilder.Entity<Gift>()
                .HasOne(g => g.PriceFrom)
                .WithMany(p => p.GiftsPriceFrom);

            modelBuilder.Entity<Gift>()
                .HasOne(g => g.PriceTo)
                .WithMany(p => p.GiftsPriceTo);

            modelBuilder.Entity<Gift>()
                .HasIndex(g => g.GiftName).IsUnique();
        }
    }
}
