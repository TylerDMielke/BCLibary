using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BCLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BCLibraryWebApp.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BCLibraryWebApp.Data.BCLibraryWebAppContext _context;

        public IndexModel(BCLibraryWebApp.Data.BCLibraryWebAppContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Authors { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BookAuthor { get; set; }

        public async Task OnGetAsync()
        {
            // Select all books using LINQ 
            var books = from b in _context.Book
                        select b;

            // TODO: Determine if this is needed without author filter
            IQueryable<string> authorQuery = from b in _context.Book
                                             orderby b.Author
                                             select b.Author;

            if (!string.IsNullOrEmpty(SearchString))
                books = books.Where(b => b.Title.Contains(SearchString));

            // TODO: Determine if this is needed without author filter
            if (!string.IsNullOrEmpty(BookAuthor))
                books = books.Where(b => b.Author == BookAuthor);

            Authors = new SelectList(await authorQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
