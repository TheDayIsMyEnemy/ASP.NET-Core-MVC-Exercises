using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookShop.Core.DTOs;
using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository authorRepository
            , IBookRepository bookRepository
            , IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public Task<bool> AuthorExistsAsync(int authorId)
            => authorRepository.ExistsAsync(authorId);

        public async Task<int> CreateAsync(string firstName, string lastName)
        {
            Author author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };
            await authorRepository.CreateAsync(author);
            return author.Id;
        }

        public async Task<AuthorWithBookTitlesDto> GetAuthorWithBookTitlesByIdAsync(int authorId)
        {
            Author author = await authorRepository.GetAuthorWithBooksByIdAsync(authorId);
            return mapper.Map<Author, AuthorWithBookTitlesDto>(author);
        }

        public async Task<IEnumerable<BookWithCategoriesDto>> GetBooksByAuthorAsync(int authorId)
        {
            IEnumerable<Book> books = await bookRepository.GetBooksByAuthorAsync(authorId);
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookWithCategoriesDto>>(books);
        }
    }
}
