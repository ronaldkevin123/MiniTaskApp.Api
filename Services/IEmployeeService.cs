using MiniTaskApp.Api.DTOs;

namespace MiniTaskApp.Api.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeAsync(int id);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(int id, EmployeeDto dto);
        Task<bool> DeleteEmployeeAsync(int id);
    }
}