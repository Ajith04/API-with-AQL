using Microsoft.EntityFrameworkCore;
using SQL_Last_Assignment.DbContexts;
using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly CompanyDbContext _companydbcontext;

        public OrderRepo(CompanyDbContext companydbcontext)
        {
            _companydbcontext = companydbcontext;
        }

        public async Task<List<Order>> getOrderByDate(DateTime start_date, DateTime end_date)
        {
            var filteredOrders = await _companydbcontext.Orders.Where(r => r.OrderDate > start_date && r.OrderDate < end_date).ToListAsync();
            return filteredOrders;
        }

        public async Task<List<CustomerGroups>> getOrdersByCustomer()
        {
            var customerGroup = await _companydbcontext.Orders.GroupBy(r => r.CustomerId).Select(g => new { CustomerId = g.Key, TotalAmount = g.Sum(o => o.TotalAmount) }).ToListAsync();
            
            var customerGroupList = new List<CustomerGroups>();

            foreach(var customer in customerGroup)
            {
                var customerGroups = new CustomerGroups();
                customerGroups.CustomerId = customer.CustomerId;
                customerGroups.TotalAmount = customer.TotalAmount;

                customerGroupList.Add(customerGroups);
            }

            return customerGroupList;

        }

        public async Task<string> updateOrderByStatus(Guid id)
        {
            var order = _companydbcontext.Orders.Find(id);
            if(order != null)
            {
                if(order.Status == "Pending")
                {
                    order.Status = "Completed";
                    await _companydbcontext.SaveChangesAsync();
                    return "Successfully changed";
                }
                else
                {
                    return "The Order is already Completed";
                }
            }
            else
            {
                return null;
            }
        }
    }
}
