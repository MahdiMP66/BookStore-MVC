﻿using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
