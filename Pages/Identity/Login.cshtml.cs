using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BCLibraryWebApp.Pages.Identity
{
    public class LoginModel : PageModel
    {
        private readonly BCLibraryWebApp.Data.BCLibraryWebAppContext context;
        private readonly IConfiguration configuration;
        public LoginModel(IConfiguration configuration,
            BCLibraryWebApp.Data.BCLibraryWebAppContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await context.User.FirstOrDefaultAsync(u => u.Username == UserName && u.Password == Password);

            if(user == null)
            {
                Message = "Login failed. Check Username and Password";
                return Page();
            }
            else
                return RedirectToPage("../Books/Index");
        }
    }
}
