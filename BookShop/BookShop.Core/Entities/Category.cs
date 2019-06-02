using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public List<CategoryBook> Books { get; set; } = new List<CategoryBook>();
    }
}
