using BookShop.Core.Entities;
using BookShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookShop.Core.DTOs;

namespace BookShop.Infrastructure.Data
{
    public class BookRepository : EfRepository<Book>, IBookRepository
    {
        public BookRepository(BookShopDbContext db) : base(db)
        {

        }

        public async Task<IEnumerable<Book>> SearchAsync(string word, int count)
            => await db.Books.Where(b => b.Title.ToLower().Contains(word.ToLower())).Take(count).OrderBy(b => b.Title).ToListAsync();


        public async Task<Book> GetBookDetailsAsync(int id)
            => await db.Books
                .Include(b => b.Author)
                .Include(b => b.Categories)
                .ThenInclude(bc => bc.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
                

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
            => await db.Books
                .Include(b => b.Categories)
                .ThenInclude(bc => bc.Category)
                .Where(b => b.AuthorId == authorId)
                .ToListAsync();
    }
}
