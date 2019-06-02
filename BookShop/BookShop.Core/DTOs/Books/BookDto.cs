using BookShop.Common.Mappings;
using BookShop.Core.Entities;

namespace BookShop.Core.DTOs
{
    public class BookDto : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public int Copies { get; set; }
        public int? Edition { get; set; }
    }
}
