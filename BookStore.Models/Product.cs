﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title{ get; set; } = string.Empty;
        [Required]
        public string ISBN { get; set; } = "default";
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        [Range(1, 1000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; } = 10;

        [Range(1, 1000)]
        [Display(Name = "Price for 1-50")]
        public double Price { get; set; } = 10;

        [Range(1, 1000)]
        [Display(Name = "Price for 50+")]
        public double Price50 { get; set; } = 10;
        [Range(1, 1000)]
        [Display(Name = "Price for 100+")]
        public double Price100 { get; set; } = 10;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }        
        public string ImageUrl { get; set; }


    }
}
