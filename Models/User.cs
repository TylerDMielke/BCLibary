using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCLibraryWebApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
