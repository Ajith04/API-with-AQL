using SQL_Last_Assignment.DTO.ResponseDTO;
using SQL_Last_Assignment.IRepositories;
using SQL_Last_Assignment.IServices;

namespace SQL_Last_Assignment.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _iemployeerepo;

        public EmployeeService(IEmployeeRepo iemployeerepo)
        {
            _iemployeerepo = iemployeerepo;
        }

        public async Task<List<EmployeeResponseDTO>> getEmployeeByName(string FirstName_or_LastName)
        {
            var employeeByName = await _iemployeerepo.getEmployeeByName(FirstName_or_LastName);

            var employeeList = new List<EmployeeResponseDTO>();

            foreach (var employee in employeeByName)
            {
                var singleEmployee = new EmployeeResponseDTO();
                singleEmployee.Id = employee.Id;
                singleEmployee.FirstName = employee.FirstName;
                singleEmployee.LastName = employee.LastName;
                singleEmployee.HireDate = employee.HireDate;
                singleEmployee.Department = employee.Department;
                singleEmployee.JobTitle = employee.JobTitle;
                employeeList.Add(singleEmployee);
            }

            return employeeList;
        }

        public async Task<List<EmployeeResponseDTO>> getEmployeeByAscending()
        {
            var employeeList = await _iemployeerepo.getEmployeeByAscending();

            var employeeListResponse = new List<EmployeeResponseDTO>();

            foreach(var employee in employeeList)
            {
                var singleEmployee = new EmployeeResponseDTO();
                singleEmployee.Id = employee.Id;
                singleEmployee.FirstName = employee.FirstName;
                singleEmployee.LastName = employee.LastName;
                singleEmployee.HireDate= employee.HireDate;
                singleEmployee.Department = employee.Department;
                singleEmployee.JobTitle= employee.JobTitle;

                employeeListResponse.Add(singleEmployee);
            }

            return employeeListResponse;
        }

        public async Task<List<EmployeeResponseDTO>> multiFieldSearch(string department, string job_title)
        {
            var employees = await _iemployeerepo.multiFieldSearch(department, job_title);

            var EmployeeList = new List<EmployeeResponseDTO>();

            foreach (var employee in employees)
            {
                var singleEmployee = new EmployeeResponseDTO();
                singleEmployee.Id = employee.Id;
                singleEmployee.FirstName = employee.FirstName;
                singleEmployee.LastName = employee.LastName;
                singleEmployee.HireDate = employee.HireDate;
                singleEmployee.Department = employee.Department;
                singleEmployee.JobTitle = employee.JobTitle;

                EmployeeList.Add(singleEmployee);
            }

            return EmployeeList;
        }
    }
}
