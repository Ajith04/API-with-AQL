using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SQL_Last_Assignment.DbContexts;
using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly CompanyDbContext _companydbcontext;

        public CustomerRepo(CompanyDbContext companydbcontext)
        {
            _companydbcontext = companydbcontext;
        }

        public async Task<Customer> getCustomerById(Guid id)
        {
            var singleCustomer = await _companydbcontext.Customers.SingleOrDefaultAsync(r => r.Id == id);
            return singleCustomer;
        }

        public async Task<Customer> updateCustomer(Guid id, Customer customer)
        {
            var updateCustomer = _companydbcontext.Customers.Find(id);
            if (updateCustomer != null)
            {
                updateCustomer.FirstName = customer.FirstName;
                updateCustomer.LastName = customer.LastName;
                updateCustomer.Email = customer.Email;
                await _companydbcontext.SaveChangesAsync();
                return updateCustomer;
            }
            else
            {
                return null;
            }


        }

        public async Task<string> removeCustomerByStatus(Guid id)
        {
            var customer = _companydbcontext.Customers.Find(id);
            if (customer != null)
            {
                if (customer.IsActive == false) {
                    _companydbcontext.Customers.Remove(customer);
                    await _companydbcontext.SaveChangesAsync();
                    return "Successfully Deleted";
                }
                else
                {
                    return "The Customer is an active customer";
                }
            }
            else
            {
                return null;
            }
        }

        public int getActiveCustomers()
        {
            var count = _companydbcontext.Customers.Count(r => r.IsActive == true);
            return count;
        }
    }
}
