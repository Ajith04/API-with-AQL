using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _iemployeeservice;

        public EmployeeController(IEmployeeService iemployeeservice)
        {
            _iemployeeservice = iemployeeservice;
        }

        [HttpGet ("get-employee-by-name/{FirstName_or_LastName}")]
        public async Task<IActionResult> getEmployeeByName(string FirstName_or_LastName)
        {
            var employeeByName = await _iemployeeservice.getEmployeeByName(FirstName_or_LastName);
            return Ok(employeeByName);
        }

        [HttpGet ("get-employees-by-ascending")]
        public async Task<IActionResult> getEmployeeByAscending()
        {
            var orderedEmployees = await _iemployeeservice.getEmployeeByAscending();
            return Ok(orderedEmployees);
        }

        [HttpGet ("multi-field-search/{Department},{Job_Title}")]
        public async Task<IActionResult> multiFieldSearch(string Department, string Job_Title)
        {
            var employeeList = await _iemployeeservice.multiFieldSearch(Department, Job_Title);
            return Ok(employeeList);
        }
    }
}
