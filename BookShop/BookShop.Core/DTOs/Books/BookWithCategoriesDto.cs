using AutoMapper;
using BookShop.Common.Mappings;
using BookShop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Core.DTOs
{
    public class BookWithCategoriesDto : BookDto, IHaveCustomMapping
    {
        public List<string> Categories { get; set; }

        public virtual void ConfigureMapping(Profile mapper)    
            => mapper.CreateMap<Book, BookWithCategoriesDto>()
                .ForMember(dto => dto.Categories, cfg =>
                cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)));
        
    }
}
