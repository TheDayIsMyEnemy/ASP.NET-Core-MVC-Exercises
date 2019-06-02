using BookShop.Core.DTOs;
using BookShop.Core.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShop.Core.Interfaces
{
    public interface IBookRepository : IAsyncRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);

        Task<Book> GetBookDetailsAsync(int id);

        Task<IEnumerable<Book>> SearchAsync(string word, int count);
    }
}
