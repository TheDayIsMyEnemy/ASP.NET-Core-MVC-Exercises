using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.DTOs;

namespace BookShop.Core.Interfaces
{
    public interface IBookService
    {
        Task<BookWithAuthorAndCategoriesDto> GetBookDetailsAsync(int id);

        Task<IEnumerable<BookBasicDto>> SearchAsync(string word, int count);

        Task<BookDto> EditBook(int id, string title, string description, decimal price, int copies, int? edition, int authorId);

        Task<BookDto> DeleteBookAsync(int id);
        Task<int> CreateBookAsync(string title, string description, decimal price, int copies, int? edition, int authorId, List<string> categories);
    }
}
