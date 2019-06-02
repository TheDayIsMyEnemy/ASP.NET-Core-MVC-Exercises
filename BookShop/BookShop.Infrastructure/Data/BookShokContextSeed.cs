using BookShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookShop.Infrastructure.Data
{
    public class BookShopContextSeed
    {
        public static void Seed(BookShopDbContext context)
        {
            context.Database.Migrate();

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Isaac",
                        LastName = "Asimov",
                    },
                    new Author
                    {
                        FirstName = "John",
                        LastName = "Tolkien",
                    },
                    new Author
                    {
                        FirstName = "Stephen",
                        LastName = "King"
                    }
                    );
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "I, Robot",
                        AuthorId = 1,
                        Price = 17.99m,
                        Copies = 10,
                        Description = string.Empty,
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        AuthorId = 2,
                        Price = 49.99m,
                        Copies = 100,
                        Description = string.Empty
                    },
                    new Book
                    {
                        Title = "A Middle-earth Traveller",
                        AuthorId = 2,
                        Price = 21.99m,
                        Copies = 20,
                        Description = string.Empty
                    },
                    new Book
                    {
                        Title = "It",
                        AuthorId = 3,
                        Price = 15.99m,
                        Copies = 30,
                        Description = string.Empty
                    }
                    );
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category {  Name = "Science fiction",  }
                    );

                context.SaveChanges();
            }

            if (!context.BooksInCategories.Any())
            {
                context.BooksInCategories.AddRange(
                    new CategoryBook {  CategoryId = 1, BookId = 1 }
                    );
            }

            context.SaveChanges();
        }
    }
}
