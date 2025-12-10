using WebApi_Ramya.DataBaseLayer;
using WebApi_Ramya.Models;




namespace WebApi_Ramya.Business_Logic
{
    public class EmployeeService:IEmployeeService

    {
       
           private readonly IEmployeeRepository _employeeRepository;

            public EmployeeService(IEmployeeRepository employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public IEnumerable<Employee> GetAll()
            {
                return _employeeRepository.GetAll();
            }

            public Employee? GetById(int id)
            {
                return _employeeRepository.GetById(id);
            }

            public Employee? GetByName(string name)
            {
                return _employeeRepository.GetByName(name);
            }

            public void Add(Employee employee)
            {
                _employeeRepository.Add(employee);
            }

            public void Update(Employee employee)
            {
                _employeeRepository.Update(employee);
            }

            public void Delete(int id)
            {
                _employeeRepository.Delete(id);
            }
        }
    }




