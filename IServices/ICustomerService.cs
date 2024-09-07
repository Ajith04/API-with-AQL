using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.DTO.ResponseDTO;

namespace SQL_Last_Assignment.IServices
{
    public interface ICustomerService
    {
        Task<CustomerResponseDTO> getCustomerById(Guid id);

        Task<CustomerResponseDTO> updateCustomer(Guid id, CustomerRequestDTO customerrequestdto);

        Task<string> removeCustomerByStatus(Guid id);

        int getActiveCustomers();
    }
}
