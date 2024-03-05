using HrApp.Data;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetById(int? id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                throw new KeyNotFoundException();
            }
            return employee;
        }

        public async Task Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(); //aparte method van maken (ook in Interface)
        }

        public async Task Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
             var existing = await _context.Employees.FindAsync(employee.EmployeeId);

            if (existing == null)
            {
                throw new KeyNotFoundException();
            }

            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await _context.SaveChangesAsync();
        //}
    }
}
