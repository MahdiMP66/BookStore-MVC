using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {ID = 1, Name = "Action",DisplayOrder = 2 },
                new Category { ID = 2, Name = "Drama", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Story", DisplayOrder = 3 });
        }
    }
}
