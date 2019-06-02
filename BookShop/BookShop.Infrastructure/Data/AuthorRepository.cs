using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure.Data
{
    public class AuthorRepository : EfRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookShopDbContext db) : base(db)
        {

        }

        public async Task<Author> GetAuthorWithBooksByIdAsync(int authorId)
            => await db.Authors
                    .Include(a => a.Books)
                    .Where(a => a.Id == authorId)
                    .FirstOrDefaultAsync();
    }
}
