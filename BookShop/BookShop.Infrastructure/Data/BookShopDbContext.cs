using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options) : base(options)
        {
        }
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBook> BooksInCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<Author>()
                .Property(a => a.Id)
                .ValueGeneratedOnAdd();

            builder
                .Entity<CategoryBook>()
                .HasKey(cb => new { cb.BookId, cb.CategoryId });

            builder
                .Entity<CategoryBook>()
                .HasOne(cb => cb.Book)
                .WithMany(b => b.Categories)
                .HasForeignKey(cb => cb.BookId);

            builder
                .Entity<CategoryBook>()
                .HasOne(cb => cb.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(cb => cb.CategoryId);
                
            builder
                .Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
