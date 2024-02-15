using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category {ID = 1, Name = "Action",DisplayOrder = 2 },
                new Category { ID = 2, Name = "Drama", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Story", DisplayOrder = 3 });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Action",
                    ISBN = "1",
                    Description = "desc1"
                    ,
                    Author = "mahdi1",
                    ListPrice = 50,
                    Price = 50,
                    Price50 = 50,
                    Price100 = 50
                },
                new Product
                {
                    Id = 2,
                    Title = "Drama",
                    ISBN = "1",
                    Description = "desc2"
                    ,
                    Author = "mahdi2",
                    ListPrice = 50,
                    Price = 50,
                    Price50 = 50,
                    Price100 = 50
                },
               new Product
               {
                   Id = 3,
                   Title = "horor",
                   ISBN = "1",
                   Description = "desc3"
                    ,
                   Author = "mahdi3",
                   ListPrice = 50,
                   Price = 50,
                   Price50 = 50,
                   Price100 = 50
               });
        }
    }
}
