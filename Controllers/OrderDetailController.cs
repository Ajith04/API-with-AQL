using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _iorderdetailservice;

        public OrderDetailController(IOrderDetailService iorderdetailservice)
        {
            _iorderdetailservice = iorderdetailservice;
        }
    }
}
