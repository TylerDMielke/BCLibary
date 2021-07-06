using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BCLibraryWebApp.Pages.Identity
{
    public class SignupModel : PageModel
    {
        private readonly IConfiguration configuration;
        public SignupModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            if (regex.IsMatch(UserName))
            {
                // TODO: Hash the password and then post
            }
            else
                Message = "Username must be alphanumeric";
            //   var passwordHasher = new PasswordHasher<string>();
            //    if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
            //    {
            //        var claims = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.Name, UserName)
            //        };
            //        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            //        return RedirectToPage("/admin/index");
            //    }
            return Page();
        }

        public void OnGet()
        {
        }
    }
}
