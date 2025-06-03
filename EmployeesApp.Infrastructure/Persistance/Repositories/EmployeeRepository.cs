using EmployeesApp.Infrastructure.Persistance;
using EmployeesApp.Application.Employees.Interfaces;
using EmployeesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Infrastructure.Persistance.Repositories
{
    public class EmployeeRepository(ApplicationContext context) : IEmployeeRepository
    {
        public void Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        //readonly List<Employee> employees =
        //[
        //    new Employee()
        //{
        //    Id = 562,
        //    Name = "Anders Hejlsberg",
        //    Email = "Anders.Hejlsberg@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 62,
        //    Name = "Kathleen Dollard",
        //    Email = "k.d@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 15662,
        //    Name = "Mads Torgersen",
        //    Email = "Admin.Torgersen@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 52,
        //    Name = "Scott Hanselman",
        //    Email = "s.h@outlook.com",
        //},
        //new Employee()
        //{
        //    Id = 563,
        //    Name = "Jon Skeet",
        //    Email = "j.s@outlook.com",
        //},
        //];

        public async Task AddAsync(Employee employee)
        {
            context.Employees?.AddAsync(employee);
            await context.SaveChangesAsync(); // Inte glömma!
        }

        public Employee[] GetAll()
        {
            throw new NotImplementedException();
        }

        //Classic C# syntax for GetAll()
        public async Task<Employee[]> GetAllAsync()
        {
            return await context.Employees.ToArrayAsync();
        }

        public Employee? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task <Employee?> GetByIdAsync(int id)
        {
            return await context.Employees.FindAsync(id);

        }
    }
}