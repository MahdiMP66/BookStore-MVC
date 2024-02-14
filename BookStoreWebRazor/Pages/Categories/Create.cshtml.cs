using BookStoreWebRazor.Data;
using BookStoreWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreWebRazor.Pages.Categories
{
    //[BindProperties]
    public class CreateModel : PageModel
    {
        private readonly DataContext _db;
        [BindProperty]
        public Category category { get; set; }
        public CreateModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "name and display order must be diferent");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
