using MiniTaskApp.Api.Data;
using MiniTaskApp.Api.DTOs;
using MiniTaskApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MiniTaskApp.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees.Select(ToEmployeeDto).ToList();
        }

        public async Task<EmployeeDto?> GetEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee == null ? null : ToEmployeeDto(employee);
        }

        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeNo = dto.EmployeeNo,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _context.Employees.Add(employee);
            
            await _context.SaveChangesAsync();
            return ToEmployeeDto(employee);
        }

        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeDto dto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            employee.EmployeeNo = dto.EmployeeNo;
            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.IsActive = dto.IsActive;
            employee.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();
            return true;
        }

        private EmployeeDto ToEmployeeDto(Employee e)
        {
            return new EmployeeDto
            {
                EmployeeId = e.EmployeeId,
                EmployeeNo = e.EmployeeNo,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                IsActive = e.IsActive,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
        }
    }
}