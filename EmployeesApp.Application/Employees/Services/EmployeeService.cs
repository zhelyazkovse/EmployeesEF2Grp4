﻿using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    public void Add(Employee employee)
    {
        employee.Name = ToInitalCapital(employee.Name);
        employee.Email = employee.Email.ToLower();
        employeeRepository.Add(employee);
    }

    string ToInitalCapital(string s) => $"{s[..1].ToUpper()}{s[1..]}";

    public Employee[] GetAllAsync() => [.. employeeRepository.GetAll().OrderBy(e => e.Name)];

    public Employee? GetByIdAsync(int id)
    {
        Employee? employee = employeeRepository.GetById(id);

        return employee is null ?
            throw new ArgumentException($"Invalid parameter value: {id}", nameof(id)) :
            employee;
    }

    public bool CheckIsVIP(Employee employee) =>
        employee.Email.StartsWith("ANDERS", StringComparison.CurrentCultureIgnoreCase);
}