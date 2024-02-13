using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookStoreWebRazor.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Category Name")]
        //[MaxLength(20,ErrorMessage = "should be less than 20 letters")]
        [MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }
    }
}
