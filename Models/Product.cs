
using System.ComponentModel.DataAnnotations;

namespace SQL_Last_Assignment.Models
{
    public class Product
    {
        [Key] public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
