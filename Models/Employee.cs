
using System.ComponentModel.DataAnnotations;

namespace SQL_Last_Assignment.Models
{
    public class Employee
    {
        [Key] public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }

    }
}
