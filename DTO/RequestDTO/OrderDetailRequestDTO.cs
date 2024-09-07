namespace SQL_Last_Assignment.DTO.RequestDTO
{
    public class OrderDetailRequestDTO
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
