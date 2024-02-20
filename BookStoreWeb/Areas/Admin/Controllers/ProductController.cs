using BookStore.DataAccess.IRepository;
using BookStore.Models;
using BookStore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWeb.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        private  IWebHostEnvironment _webHostEnvironment { get; }

        public ProductController(IProductRepository productRepository,
            ICategoryRepository categoryRepository,IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
            
        }
        public IActionResult Index()
        {
            var Products =  _productRepository.GetAll("Category").ToList();
            return View(Products);
        }
        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _categoryRepository.GetAll()
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString(),
                });
            //ViewBag.CategoryList = CategoryList;
            ProductVM viewModel = new ProductVM()
            {
                Product = new Product(),
                CategoryList = CategoryList
            };
            if (id == null || id == 0) {
                
                return View(viewModel);
            }
            else
            {
                viewModel.Product = _productRepository.GetSingle(p => p.Id == id);
                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM request,IFormFile? image)
        {
            if(request.Product.Title == request.Product.Description)
            {
                ModelState.AddModelError("Description", "Title and Description can not be same!");
            }
            if(ModelState.IsValid)
            {
                string rootPath = _webHostEnvironment.WebRootPath;
                if(image != null)
                {
                    if (!string.IsNullOrEmpty(request.Product.ImageUrl))
                    {
                        string oldPath = Path.Combine(rootPath, request.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldPath))
                            System.IO.File.Delete(oldPath);

                    }
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string path = Path.Combine(rootPath, @"Images\Product");
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        image.CopyTo(filestream);
                    }
                    request.Product.ImageUrl = @"\Images\Product\" + filename;
                }

                if (request.Product.Id == 0 || request.Product.Id == null)
                {
                    _productRepository.Add(request.Product);
                    _productRepository.Save();
                    TempData["success"] = "Product added successfully";
                }
                else
                {
                    _productRepository.Update(request.Product);
                    _productRepository.Save();
                    TempData["success"] = "Product updated successfully";
                }
                return RedirectToAction("Index");
            }
            request.CategoryList = _categoryRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            });
            return View(request);
        }




        #region api calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList =  _productRepository.GetAll(includeProperties:"Category").ToList();
            return Json(new { data = productList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var dbProduct = _productRepository.GetSingle(p => p.Id == id,"Category");
            if (dbProduct == null)
            {
                return Json(new {success =  false, message = "Error while deleteing"});
            }
            string rootPath = _webHostEnvironment.WebRootPath;
            string delPath = Path.Combine(rootPath, dbProduct.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(delPath))
            {
                System.IO.File.Delete(delPath);
            }
            _productRepository.Remove(dbProduct);
            _productRepository.Save();
            //TempData["success"] = "Product deleted successfully"; it is handles on product.js
            return Json(new { success = false, message = "Product deleted successfully" });
        }

        #endregion
    }
}
