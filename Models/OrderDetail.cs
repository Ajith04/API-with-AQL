
using System.ComponentModel.DataAnnotations;

namespace SQL_Last_Assignment.Models
{
    public class OrderDetail
    {
        [Key] public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
