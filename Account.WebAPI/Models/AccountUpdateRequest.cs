using System;
using System.ComponentModel.DataAnnotations;

namespace Account.WebAPI.Models
{
    public class AccountUpdateRequest
    {
        [StringLength(10, MinimumLength = 3)]
        public string Password { get; set; }

        public string FirstName { get; set; }
    }
}
