using System.ComponentModel.DataAnnotations;

namespace BCLibraryWebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
