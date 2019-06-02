using AutoMapper;
using BookShop.Core.Entities;
using System.Linq;

namespace BookShop.Core.DTOs
{
    public class BookWithAuthorAndCategoriesDto : BookWithCategoriesDto
    {
        public int AuthorId { get; set; }

        public string Author { get; set; }

        public override void ConfigureMapping(Profile mapper)
            => mapper.CreateMap<Book, BookWithAuthorAndCategoriesDto>()
                .ForMember(dto => dto.Author, cfg =>
                    cfg.MapFrom(b => $"{b.Author.FirstName} {b.Author.LastName}"))
                 .ForMember(dto => dto.Categories, cfg =>
                    cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
    }
}
