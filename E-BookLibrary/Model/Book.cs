using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Model
{
    public class Book
    {
       
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime DatePublished { get; set; }
        public DateTime DateAddedToLibrary { get; set; }
        public string ISBN { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public int AvailableCopies { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Review> Review { get; set; }
        public Rating Rating { get; set; }
        public string SubCategory { get; set; }

    }
}
