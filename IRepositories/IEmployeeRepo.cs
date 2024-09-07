using SQL_Last_Assignment.Models;

namespace SQL_Last_Assignment.IRepositories
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> getEmployeeByName(string FirstName_or_LastName);
        Task<List<Employee>> getEmployeeByAscending();
        Task<List<Employee>> multiFieldSearch(string department, string job_title);
    }
}
