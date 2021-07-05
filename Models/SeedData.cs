using BCLibraryWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BCLibraryWebApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BCLibraryWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BCLibraryWebAppContext>>()))
            {
                // Check if database already has books
                if(context.Book.Any())
                {
                    return; // The database doesn't need to be initialized
                }
                context.Book.AddRange(
                    new Book
                    {
                        Title = "Don Quixote",
                        Author = "Miguel De Cervantes",
                        ReleaseDate = DateTime.Parse("1605-1-1")
                    },
                    new Book
                    {
                        Title = "Kubla Khan: or A Vision in a Dream",
                        Author = "Samuel Taylor Coleridge",
                        ReleaseDate = DateTime.Parse("1797-1-1")
                    },
                    new Book
                    {
                        Title = "Crime and Punishment",
                        Author = "Fyodor Dostoevsky",
                        ReleaseDate = DateTime.Parse("1866-1-1")
                    },
                    new Book
                    {
                        Title = "Frankenstein",
                        Author = "Mary Shelley",
                        ReleaseDate = DateTime.Parse("1823-1-1")
                    },
                    new Book
                    {
                        Title = "The Lord of the Rings",
                        Author = "J. R. R. Tolkien",
                        ReleaseDate = DateTime.Parse("1954-1-1")
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}

