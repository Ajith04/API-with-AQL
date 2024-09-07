using SQL_Last_Assignment.DTO.ResponseDTO;

namespace SQL_Last_Assignment.IServices
{
    public interface IOrderService
    {
        Task<List<OrderResponseDTO>> getOrderByDate(DateTime start_date, DateTime end_date);

        Task<List<CustomerGroups>> getOrdersByCustomer();

        Task<string> updateByOrderStatus(Guid id);
    }
}
