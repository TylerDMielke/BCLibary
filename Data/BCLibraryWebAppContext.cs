using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BCLibraryWebApp.Models;

namespace BCLibraryWebApp.Data
{
    public class BCLibraryWebAppContext : DbContext
    {
        public BCLibraryWebAppContext (DbContextOptions<BCLibraryWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<BCLibraryWebApp.Models.Book> Book { get; set; }
    }
}
