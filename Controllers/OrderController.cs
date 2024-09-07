using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _iorderservice;

        public OrderController(IOrderService iorderservice)
        {
            _iorderservice = iorderservice;
        }

        [HttpGet ("get-orders-by-date/{Start_Date}, {End_Date}")]
        public async Task<IActionResult> getOrderByDate(DateTime Start_Date, DateTime End_Date)
        {
           
                var filteredOrders = await _iorderservice.getOrderByDate(Start_Date, End_Date);
                return Ok(filteredOrders);
                        
        }

        [HttpGet ("get-Orders-by-customer")]
        public async Task<IActionResult> getOrdersByCustomer()
        {
            var customers = await _iorderservice.getOrdersByCustomer();
            return Ok(customers);
        }

        [HttpPut("update-by-order-status/{id}")]
        public async Task<IActionResult> updateByOrderStatus(Guid id)
        {
            try
            {
                var status = await _iorderservice.updateByOrderStatus(id);
                return Ok(status);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
