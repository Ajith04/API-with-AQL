namespace SQL_Last_Assignment.DTO.ResponseDTO
{
    public class EmployeeResponseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }

    }
}
