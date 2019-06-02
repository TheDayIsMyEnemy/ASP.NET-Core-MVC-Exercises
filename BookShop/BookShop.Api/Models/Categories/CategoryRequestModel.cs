using System.ComponentModel.DataAnnotations;

namespace BookShop.Api.Models.Categories
{
    public class CategoryRequestModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
