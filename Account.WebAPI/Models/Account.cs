using System;
namespace Account.WebAPI.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBorn { get; set; }
        public string Email { get; set; }
    }

}
