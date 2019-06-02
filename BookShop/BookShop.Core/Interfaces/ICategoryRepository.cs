using BookShop.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookShop.Core.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task AddCategoriesToBookAsync(Book book, IEnumerable<string> categories);

        Task<bool> ExistsAsync(string name);
    }
}
