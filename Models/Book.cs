using System;
using System.ComponentModel.DataAnnotations;

namespace BCLibraryWebApp.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [Display(Name = "Checked Out")]
        public bool CheckedOut { get; set; } 

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
