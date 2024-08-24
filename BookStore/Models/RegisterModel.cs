using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RegisterModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
