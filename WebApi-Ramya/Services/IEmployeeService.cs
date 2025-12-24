using WebApi_Ramya.Models;

//namespace WebApi_Ramya.DataBaseLayer;

namespace WebApi_Ramya.Business_Logic



{
    public interface IEmployeeService
    {
            IEnumerable<Employee> GetAll();
            Employee? GetById(int id);
            Employee? GetByName(string name);
            void Add(Employee employee);
            void Update(Employee employee);
            void Delete(int id);
        }
    }


