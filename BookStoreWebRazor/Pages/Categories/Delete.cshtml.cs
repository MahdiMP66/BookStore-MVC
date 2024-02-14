using BookStoreWebRazor.Data;
using BookStoreWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreWebRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly DataContext _db;

        public DeleteModel(DataContext db)
        {
            _db = db;
        }
        public Category category { get; set; }
        public void OnGet(int id)
        {
            var dbCategory = _db.Categories.FirstOrDefault(c => c.ID ==  id);
            if (dbCategory != null)
            {
                category = dbCategory;
            }
        }
        public IActionResult OnPost()
        {
           
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToPage("Index");
            
           // return Page();
        }
    }
}
