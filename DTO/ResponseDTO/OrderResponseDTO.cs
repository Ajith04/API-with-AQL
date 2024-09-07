namespace SQL_Last_Assignment.DTO.ResponseDTO
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
