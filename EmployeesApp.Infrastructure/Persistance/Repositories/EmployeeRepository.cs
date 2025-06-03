using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        public async Task AddAsync(Employee employee)
        {
            context.Employees?.AddAsync(employee);
            await context.SaveChangesAsync(); // Inte glömma!
        }

        //Classic C# syntax for GetAll()
        public async Task<Employee[]> GetAllAsync()
        {
            return await context.Employees.ToArrayAsync();
        }

        public async Task <Employee?> GetByIdAsync(int id)
        {
            return await context.Employees.FindAsync(id);

        }
    }
}