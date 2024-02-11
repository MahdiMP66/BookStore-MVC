using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _db;

        public CategoryController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> Categories = _db.Categories.ToList();
            return View(Categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.ID == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
            }
            return RedirectToAction("Index");
        }
    }
}
