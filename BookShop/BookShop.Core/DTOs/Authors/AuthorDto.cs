using BookShop.Common.Mappings;
using BookShop.Core.Entities;

namespace BookShop.Core.DTOs
{
    public class AuthorDto : IMapFrom<Author>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
