using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class OtherEmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public void Add(Employee employee)
    {
        employeeRepository.Add(employee);
    }

    public Employee[] GetAllAsync()
    {
        return employeeRepository.GetAll();
    }

    public Employee? GetByIdAsync(int id) => employeeRepository.GetById(id);

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ADMIN", StringComparison.CurrentCultureIgnoreCase);
}