using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
