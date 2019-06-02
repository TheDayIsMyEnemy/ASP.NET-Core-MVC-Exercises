using BookShop.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Core.Interfaces
{
    public interface IAuthorService
    {
        Task<bool> AuthorExistsAsync(int authorId);
        Task<int> CreateAsync(string firstName, string lastName);
        Task<AuthorWithBookTitlesDto> GetAuthorWithBookTitlesByIdAsync(int authorId);

        Task<IEnumerable<BookWithCategoriesDto>> GetBooksByAuthorAsync(int authorId);
    }
}
