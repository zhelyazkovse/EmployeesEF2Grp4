using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApp.Application.Employees.Services;

public class OtherEmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public async Task AddAsync(Employee employee)
    {
        await employeeRepository.AddAsync(employee);
    }

    public async Task<Employee[]> GetAllAsync()
    {
        var employees = await employeeRepository.GetAllAsync();
        return employees.OrderBy(e => e.Name).ToArray(); // This is valid!
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await employeeRepository.GetByIdAsync(id);
    }

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
}
