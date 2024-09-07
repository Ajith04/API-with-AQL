using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.IRepositories
{
    public interface ICustomerRepo
    {
        Task<Customer> getCustomerById(Guid id);
        Task<Customer> updateCustomer(Guid id, Customer customer);
        Task<string> removeCustomerByStatus(Guid id);
        int getActiveCustomers();
    }
}
