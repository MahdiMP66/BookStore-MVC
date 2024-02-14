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
            _db.Categories.Add(category);
            _db.SaveChanges();
            return Redirect("Index");
        }
    }
}
