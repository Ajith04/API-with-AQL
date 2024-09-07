
using System.ComponentModel.DataAnnotations;

namespace SQL_Last_Assignment.Models
{
    public class Order
    {
        [Key] public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }

    }
}
