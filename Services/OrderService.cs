using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _iorderrepo;

        public OrderService(IOrderRepo iorderrepo)
        {
            _iorderrepo = iorderrepo;
        }

        public async Task<List<OrderResponseDTO>> getOrderByDate(DateTime start_date, DateTime end_date)
        {
            var filteredOrders = await _iorderrepo.getOrderByDate(start_date, end_date);
          
                var filteredOrderList = new List<OrderResponseDTO>();
                foreach (var order in filteredOrders)
                {
                    var orderResponse = new OrderResponseDTO();
                    orderResponse.Id = order.Id;
                    orderResponse.CustomerId = order.CustomerId;
                    orderResponse.OrderDate = order.OrderDate;
                    orderResponse.TotalAmount = order.TotalAmount;

                    filteredOrderList.Add(orderResponse);
                }

                return filteredOrderList;
        }

        public async Task<List<CustomerGroups>> getOrdersByCustomer()
        {
            var customers = await _iorderrepo.getOrdersByCustomer();
            return customers;
        }

        public async Task<string> updateByOrderStatus(Guid id)
        {
            var status = await _iorderrepo.updateOrderByStatus(id);
            if(status != null)
            {
                return status;
            }
            else
            {
                throw new Exception("There are no such Order Id");
            }
        }
    }
}
