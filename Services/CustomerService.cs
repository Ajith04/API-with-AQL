using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.IServices;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo _icustomerrepo;

        public CustomerService(ICustomerRepo icustomerrepo)
        {
            _icustomerrepo = icustomerrepo;
        }

        public async Task<CustomerResponseDTO> getCustomerById(Guid id)
        {
            var singleCustomer = await _icustomerrepo.getCustomerById(id);
            var customerById = new CustomerResponseDTO();
            customerById.Id = singleCustomer.Id;
            customerById.FirstName = singleCustomer.FirstName;
            customerById.LastName = singleCustomer.LastName;
            customerById.Email = singleCustomer.Email;
            customerById.IsActive = singleCustomer.IsActive;

            return customerById;
        }

        public async Task<CustomerResponseDTO> updateCustomer(Guid id, CustomerRequestDTO customerrequestdto)
        {
            var customer = new Customer();
            customer.FirstName = customerrequestdto.FirstName;
            customer.LastName = customerrequestdto.LastName;
            customer.Email = customerrequestdto.Email;

            var updatedCustomer = await _icustomerrepo.updateCustomer(id, customer);

            if (updatedCustomer != null)
            {
                var customerResponse = new CustomerResponseDTO();
                customerResponse.Id = updatedCustomer.Id;
                customerResponse.FirstName = updatedCustomer.FirstName;
                customerResponse.LastName = updatedCustomer.LastName;
                customerResponse.Email = updatedCustomer.Email;
                customerResponse.IsActive = updatedCustomer.IsActive;

                return customerResponse;
            }
            else
            {
                throw new Exception("There is no record for this ID");
            }
        }

        public async Task<string> removeCustomerByStatus(Guid id)
        {
            var customer = await _icustomerrepo.removeCustomerByStatus(id);
            if (customer != null)
            {
                return customer;
            }
            else
            {
                throw new Exception("There is no such record");
            }
        }

        public int getActiveCustomers()
        {
            var count = _icustomerrepo.getActiveCustomers();
            return count;
        }
    }
}
