using AutoMapper;
using BookShop.Common.Mappings;
using BookShop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Core.DTOs
{
    public class AuthorWithBookTitlesDto : AuthorDto, IHaveCustomMapping
    {
        public List<string> BookTitles { get; set; } = new List<string>();

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Author, AuthorWithBookTitlesDto>()
                .ForMember(a => a.BookTitles, cfg => cfg
                    .MapFrom(a => a.Books.Select(b => b.Title)));
    }
}
