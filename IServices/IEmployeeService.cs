using SQL_Last_Assignment.DTO.ResponseDTO;

namespace SQL_Last_Assignment.IServices
{
    public interface IEmployeeService
    {
        Task<List<EmployeeResponseDTO>> getEmployeeByName(string FirstName_or_LastName);
        Task<List<EmployeeResponseDTO>> getEmployeeByAscending();

        Task<List<EmployeeResponseDTO>> multiFieldSearch(string department, string job_title);
    }
}
