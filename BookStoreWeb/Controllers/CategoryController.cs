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
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order can not be same!");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            Category category = _db.Categories.FirstOrDefault(u => u.ID == id)!;
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult PostDelete(int? id)
        {
            var category = _db.Categories.FirstOrDefault(c => c.ID == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Edit(int? id)
        {
            Category? category = _db.Categories.FirstOrDefault(u => u.ID == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
