using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                    Price100 = 50,
                    CategoryId = 2,
                    ImageUrl=""
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
                    Price100 = 50,
                    CategoryId = 2,
                    ImageUrl = ""
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
                   Price100 = 50,
                   CategoryId = 2,
                   ImageUrl = ""
               });
        }
    }
}
