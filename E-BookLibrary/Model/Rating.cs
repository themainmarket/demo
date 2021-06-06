using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Model
{
    public class Rating
    {
        [Required]
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Column("Rating Value")]
        public int RatingValue { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("BookId")]
        public string BookId { get; set; }
        public Book Book { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;


    }
}
