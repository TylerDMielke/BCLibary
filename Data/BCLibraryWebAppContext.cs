using BCLibraryWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BCLibraryWebApp.Data
{
    public class BCLibraryWebAppContext : DbContext
    {
        public BCLibraryWebAppContext (DbContextOptions<BCLibraryWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
    }
}
