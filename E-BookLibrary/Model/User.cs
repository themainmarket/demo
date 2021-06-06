using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_BookLibrary.Model
{
    public class User:IdentityUser
    {
        [Required]
        [Key]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        public string AvartarUrl { get; set; }
        public string publicId { get; set; } = Guid.NewGuid().ToString();
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
