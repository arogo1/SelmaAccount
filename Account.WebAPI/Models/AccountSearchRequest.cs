using System;
namespace Account.WebAPI.Models
{
    public class AccountSearchRequest
    {
        public string FirstName { get; set; }
        public string Username { get; set; }
        public string LastName { get; set; }
    }
}
