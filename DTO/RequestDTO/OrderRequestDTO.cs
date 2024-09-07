namespace SQL_Last_Assignment.DTO.RequestDTO
{
    public class OrderRequestDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
