using System.ComponentModel.DataAnnotations;

namespace BookShop.Api.Models.Books
{
    public class BookEditRequestModel
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
        public int? Edition { get; set; }
    }
}
