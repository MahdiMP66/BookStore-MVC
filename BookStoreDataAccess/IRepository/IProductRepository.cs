using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        public void Update(Product product);
        public void Save();
    }
}
