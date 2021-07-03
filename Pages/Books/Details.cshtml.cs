using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BCLibraryWebApp.Data;
using BCLibraryWebApp.Models;

namespace BCLibraryWebApp.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly BCLibraryWebApp.Data.BCLibraryWebAppContext _context;

        public DetailsModel(BCLibraryWebApp.Data.BCLibraryWebAppContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
