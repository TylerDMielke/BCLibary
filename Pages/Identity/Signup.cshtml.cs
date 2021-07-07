using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BCLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BCLibraryWebApp.Pages.Identity
{
    public class SignupModel : PageModel
    {
        private readonly BCLibraryWebApp.Data.BCLibraryWebAppContext context;
        private readonly IConfiguration configuration;
        public SignupModel(IConfiguration configuration,
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
        public string EmailAddress { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string inputVerificationResult = VerifyInput(EmailAddress, UserName, Password);
            if (inputVerificationResult == null)
            {
                User newUser = new User();
                newUser.EmailAddress = EmailAddress;
                newUser.Username = UserName;
                // TODO: Hash the password before posting it!
                newUser.Password = Password;

                this.context.User.Add(newUser);
                await this.context.SaveChangesAsync();
                return RedirectToPage("../Books/Index");
            }
            else
            {
                Message = inputVerificationResult;
                return Page();
            }
        }

        private string VerifyInput(string emailAddress, string userName, string password)
        {
            string errorMessage = null;

            errorMessage = VerifyEmailAddress(emailAddress);

            if (errorMessage == null)
                errorMessage = VerifyUserName(userName);

            if (errorMessage == null)
                errorMessage = VerifyPassword(password);

            return errorMessage;
        }

        private string VerifyEmailAddress(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return "Email Address cannot be blank";

            return null;
        }

        private string VerifyUserName(string userName)
        {

            if (string.IsNullOrWhiteSpace(userName))
                return "Username cannot be blank";

            Regex regex = new Regex("^[a-zA-Z0-9]*$");
            if (!regex.IsMatch(UserName))
                return "Username must be alphanumeric";

            // TODO: Verfiy that the username doesn't already exist!

            return null;
        }

        private string VerifyPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Password cannot be blank";

            return null;
        }
    }
}
