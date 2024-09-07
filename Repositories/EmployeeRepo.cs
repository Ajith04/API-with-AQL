using Microsoft.EntityFrameworkCore;
using SQL_Last_Assignment.DbContexts;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly CompanyDbContext _companydbcontext;

        public EmployeeRepo(CompanyDbContext companydbcontext)
        {
            _companydbcontext = companydbcontext;
        }

        public async Task<List<Employee>> getEmployeeByName(string FirstName_or_LastName)
        {
            var employeeByName = await _companydbcontext.Employees.Where(r => r.FirstName.Contains(FirstName_or_LastName) || r.LastName.Contains(FirstName_or_LastName)).ToListAsync();
            return employeeByName;
        }

        public async Task<List<Employee>> getEmployeeByAscending()
        {
            var orderedEmployees = await _companydbcontext.Employees.OrderBy(r => r.HireDate).ToListAsync();
            return orderedEmployees;
        }

        public async Task<List<Employee>> multiFieldSearch(string department, string job_title)
        {
            var employeeList = await _companydbcontext.Employees.Where(r => r.Department == department && r.JobTitle == job_title).ToListAsync();
            return employeeList;
        }
    }
}
