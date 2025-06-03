﻿using EmployeesApp.Domain.Entities;

namespace EmployeesApp.Application.Employees.Interfaces;

public interface IEmployeeService
{
    void Add(Employee employee);

    Employee[] GetAllAsync();

    Employee? GetByIdAsync(int id);

    public bool CheckIsVIP(Employee employee);
}
