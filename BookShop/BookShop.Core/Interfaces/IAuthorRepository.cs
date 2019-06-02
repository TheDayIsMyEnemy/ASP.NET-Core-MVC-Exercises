using BookShop.Core.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace BookShop.Core.Interfaces
{
    public interface IAuthorRepository : IAsyncRepository<Author>
    {
        Task<Author> GetAuthorWithBooksByIdAsync(int authorId);
    }
}
