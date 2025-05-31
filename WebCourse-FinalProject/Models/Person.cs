using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebCourse_FinalProject.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        public bool Admin { get; set; } = false ; 

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
       
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
       
        public string Email { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
