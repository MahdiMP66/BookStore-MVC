using BookStoreWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebRazor.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories{ get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Action", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Horor", DisplayOrder = 12 },
                new Category { ID = 3, Name = "Razor", DisplayOrder = 3 });
        }
    }
}
