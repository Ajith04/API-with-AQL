using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Last_Assignment.DTO.RequestDTO;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _icustomerservice;

        public CustomerController(ICustomerService icustomerservice)
        {
            _icustomerservice = icustomerservice;
        }

        [HttpGet ("get-customer-by-id/{id}")]
        public async Task<IActionResult> getCustomerById(Guid id)
        {
            var customerById = await _icustomerservice.getCustomerById(id);
            return Ok(customerById);
        }

        [HttpPut ("edit-customer-contact-details/{Id}")]
        public async Task<IActionResult> updateCustomer(Guid Id, CustomerRequestDTO customerrequestdto)
        {
            try
            {
                var updatedCustomer = await _icustomerservice.updateCustomer(Id, customerrequestdto);
                return Ok(updatedCustomer);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpDelete ("remove-customer-by-status/{id}")]
        public async Task<IActionResult> removeCustomerByStatus(Guid id)
        {
            try
            {
                var customer = await _icustomerservice.removeCustomerByStatus(id);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpGet ("get-active-customers")]
        public IActionResult getActiveCustomers()
        {
            var count = _icustomerservice.getActiveCustomers();
            return Ok(count);
        }
    }
}
