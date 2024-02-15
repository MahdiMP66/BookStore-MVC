using BookStore.DataAccess;
using BookStore.DataAccess.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> Categories = _categoryRepository.GetAll().ToList();
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
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Category category = _categoryRepository.GetSingle(u => u.ID == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult PostDelete(int? id)
        {
            var category = _categoryRepository.GetSingle(c => c.ID == id);
            if (category != null)
            {
                _categoryRepository.Remove(category);
                _categoryRepository.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public IActionResult Edit(int? id)
        {
            Category? category = _categoryRepository.GetSingle(c => c.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name and Display order can not be same!");
            }
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
