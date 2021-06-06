using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Model
{
    public class Category
    {
        [Required]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
