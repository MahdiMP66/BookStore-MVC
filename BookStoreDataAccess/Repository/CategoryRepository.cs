using BookStore.DataAccess.IRepository;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DataContext _db;

        public CategoryRepository(DataContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Category category)
        {
            _db.Update(category);
        }
        public void Save() 
        { 
            _db.SaveChanges();
        }

    }
}
