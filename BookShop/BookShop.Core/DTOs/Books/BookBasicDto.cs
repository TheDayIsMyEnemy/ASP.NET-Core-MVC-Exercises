using BookShop.Common.Mappings;
using BookShop.Core.Entities;

namespace BookShop.Core.DTOs
{
    public class BookBasicDto : IMapFrom<Book>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
