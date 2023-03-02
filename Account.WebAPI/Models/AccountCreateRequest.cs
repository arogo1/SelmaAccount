using System;
using System.ComponentModel.DataAnnotations;

namespace Account.WebAPI.Models
{
    public class AccountCreateRequest
    {
        [Required(ErrorMessage = "You have to provide first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You have to provide last name")]
        public string LastName { get; set; }

        public DateTime DateBorn { get; set; }

        [Required(ErrorMessage = "You have to provide email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You have to provide password")]
        [StringLength(10, MinimumLength = 3)]
        public string Password { get; set; }

        public string Username { get; set; }
    }
}
