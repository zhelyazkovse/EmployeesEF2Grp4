using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using System.Linq;
namespace EmployeesApp.Application.Employees.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public void Add(Employee employee)
    {
        employee.Name = ToInitalCapital(employee.Name);
        employee.Email = employee.Email.ToLower();
        employeeRepository.AddAsync(employee);
    }

    string ToInitalCapital(string s) => $"{s[..1].ToUpper()}{s[1..]}";

    public async Task<Employee[]> GetAllAsync()
    {
        Employee[] employees = await employeeRepository.GetAllAsync();
            
           return employees.OrderBy(e => e.Name).ToArray();
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        Employee? employee = await employeeRepository.GetByIdAsync(id);

        return employee is null ?
            throw new ArgumentException($"Invalid parameter value: {id}", nameof(id)) :
            employee;
    }

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ANDERS", StringComparison.CurrentCultureIgnoreCase);
}