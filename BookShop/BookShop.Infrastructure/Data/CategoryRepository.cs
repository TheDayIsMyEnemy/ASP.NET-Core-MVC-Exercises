using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Data
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookShopDbContext db) : base(db) { }

        public async Task AddCategoriesToBookAsync(Book book, IEnumerable<string> categories)
        {
            if (categories != null)
            {
                var categoriesToLowered =  new HashSet<string>(categories.Select(c => c.ToLower()));
                
                var categoriesById = await db.Categories
                    .Where(c => categoriesToLowered.Contains(c.Name.ToLower()))
                    .Select(c => c.Id).ToListAsync();

                categoriesById.ForEach(c => book.Categories.Add(new CategoryBook { CategoryId = c }));
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string name)
            => await db.Categories.AnyAsync(c => c.Name.ToLower() == name.ToLower());
    }
}
