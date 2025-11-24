using System.Collections.Generic;
using WebApi_Ramya.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi_Ramya.Repository_Layer
{
    namespace DataAccess
    {
        public class EmployeeRepository : IEmployeeRepository
        {
            private readonly TestDbContext _context;

            public EmployeeRepository(TestDbContext context)
            {
                _context = context;
            }

            public IEnumerable<Employee> GetAll()
            {
                return _context.Employees.ToList();
            }

            public Employee? GetById(int id)
            {
                return _context.Employees.FirstOrDefault(e => e.EmpId == id);
            }

            public Employee? GetByName(string name)
            {
                return _context.Employees.FirstOrDefault(e => e.EmpName == name);
            }

            public void Add(Employee employee)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }

            public void Update(Employee employee)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var emp = GetById(id);
                if (emp != null)
                {
                    _context.Employees.Remove(emp);
                    _context.SaveChanges();
                }
            }
        }
    }
}
    
