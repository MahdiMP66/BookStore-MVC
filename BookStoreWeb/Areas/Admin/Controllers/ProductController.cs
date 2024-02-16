using BookStore.DataAccess.IRepository;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var Products =  _productRepository.GetAll().ToList();
            return View(Products);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString(),
                });
            ViewBag.CategoryList = CategoryList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(product.Title == product.Description)
            {
                ModelState.AddModelError("Description", "Title and Description can not be same!");
            }
            if(ModelState.IsValid)
            {
                _productRepository.Add(product);
                _productRepository.Save();
                TempData["success"] = "Product added successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            var product = _productRepository.GetSingle(p => p.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        // [HttpPost,ActionName("Delete")] should be declared like this if wanted to just have int id in arguments
        public IActionResult Delete(Product product)
        {
            _productRepository.Remove(product);
            _productRepository.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var product = _productRepository.GetSingle(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(product.Title == product.Description)
            {
                ModelState.AddModelError("Description", "Title and Description can not be same!");
            }
            if (ModelState.IsValid)
            {
                _productRepository.Update(product);
                _productRepository.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
