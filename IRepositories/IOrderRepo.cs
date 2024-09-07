using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.IRepositories
{
    public interface IOrderRepo
    {
        Task<List<Order>> getOrderByDate(DateTime start_date, DateTime end_date);

        Task<List<CustomerGroups>> getOrdersByCustomer();
        Task<string> updateOrderByStatus(Guid id);
    }
}
