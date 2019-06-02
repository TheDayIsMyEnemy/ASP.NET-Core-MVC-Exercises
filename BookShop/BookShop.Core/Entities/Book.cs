using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.Core.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public int Copies { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int? Edition { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<CategoryBook> Categories { get; set; } = new List<CategoryBook>();
    }
}
