using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookStoreWebRazor.Data;
using BookStoreWebRazor.Models;
namespace BookStoreWebRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly DataContext _db;
        public List<Category> categories { get; set; }
        public IndexModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categories = _db.Categories.ToList();
        }
    }
}
