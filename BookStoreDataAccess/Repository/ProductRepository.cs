using BookStore.DataAccess.IRepository;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _db;

        public ProductRepository(DataContext db) : base(db) 
        {
           _db = db;
        }
        public void Save()
        {

            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            _db.Update(product);  
        }

    }
}
