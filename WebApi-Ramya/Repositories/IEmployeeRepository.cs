
using WebApi_Ramya.Models;


namespace WebApi_Ramya.DataBaseLayer
{
    public interface IEmployeeRepository
    {
    
  
            IEnumerable<Employee> GetAll();
            Employee? GetById(int id);
            Employee? GetByName(string name);
            void Add(Employee employee);
            void Update(Employee employee);
            void Delete(int id);
        }
    }




