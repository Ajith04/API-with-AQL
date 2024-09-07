
using System.ComponentModel.DataAnnotations;

namespace SQL_Last_Assignment.Models
{
    public class Customer
    {
        [Key] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

    }
}
