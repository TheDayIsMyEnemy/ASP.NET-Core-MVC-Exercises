using AutoMapper;
using BookShop.Core.DTOs;
using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace BookShop.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository,
                            IAuthorRepository authorRepository,
                            ICategoryRepository categoryRepository, 
                            IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.bookRepository = bookRepository;
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateBookAsync(string title, string description, decimal price, int copies, int? edition, int authorId, List<string> categories)
        {
            if (await authorRepository.ExistsAsync(authorId))
            {
                var book = new Book
                {
                    Title = title,
                    Description = description,
                    Price = price,
                    Copies = copies,
                    Edition = edition,
                    AuthorId = authorId
                };

                await bookRepository.CreateAsync(book);
                await categoryRepository.AddCategoriesToBookAsync(book, categories);
                return book.Id;
            }
            return 0;
        }

        public async Task<BookDto> DeleteBookAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                await bookRepository.DeleteAsync(book);
            }
            return mapper.Map<Book, BookDto>(book);
        }

        public async Task<BookDto> EditBook(int id, string title, string description, decimal price, int copies, int? edition, int authorId)
        {
            var book = await bookRepository.GetByIdAsync(id);
            var author = await authorRepository.GetByIdAsync(authorId);
            if (book != null && author != null)
            {
                book.Title = title;
                book.Description = description;
                book.Price = price;
                book.Copies = copies;
                book.Edition = edition;
                book.AuthorId = authorId;
                await bookRepository.UpdateAsync(book);
            }
            return mapper.Map<Book, BookDto>(book);
        }

        public async Task<BookWithAuthorAndCategoriesDto> GetBookDetailsAsync(int id)
        {
            var book = await bookRepository.GetBookDetailsAsync(id);
            return mapper.Map<Book, BookWithAuthorAndCategoriesDto>(book);
        }

        public async Task<IEnumerable<BookBasicDto>> SearchAsync(string word, int count)
        {
            var books = await bookRepository.SearchAsync(word, count);
            return mapper.Map<IEnumerable<Book>, IEnumerable<BookBasicDto>>(books);
        }


    }
}
