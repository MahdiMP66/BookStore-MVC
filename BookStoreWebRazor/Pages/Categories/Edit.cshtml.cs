using BookStoreWebRazor.Data;
using BookStoreWebRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreWebRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly DataContext _db;
        public Category category { get; set; }
        public EditModel(DataContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            var dbCategory = _db.Categories.FirstOrDefault(c => c.ID == id);
            if (dbCategory != null) 
            {
                category = dbCategory; // usage is it sets the id so we can use update method (new info will be filled in the form post request(edit.cshtml))
            }
        }
        public IActionResult OnPost() 
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "name and display order must be diferent");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return Redirect("Index");
            }
            return Page();
        }
    }
}
