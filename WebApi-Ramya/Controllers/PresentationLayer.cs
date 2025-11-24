using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Ramya.Business_Layer;
using WebApi_Ramya.Models;

namespace WebApi_Ramya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationLayer : ControllerBase
    {

             private readonly IEmployeeService _employeeService;

            public PresentationLayer(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            // GET: api/Employee
            [HttpGet]
            public IActionResult GetAll()
            {
                var employees = _employeeService.GetAll();
                return Ok(employees);
            }

            // GET: api/Employee/5
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                var emp = _employeeService.GetById(id);

                if (emp == null)
                    return NotFound();

                return Ok(emp);
            }

            // GET: api/Employee/ByName/Ramya
            [HttpGet("ByName/{name}")]
            public IActionResult GetByName(string name)
            {
                var emp = _employeeService.GetByName(name);

                if (emp == null)
                    return NotFound();

                return Ok(emp);
            }

            // POST: api/Employee
            [HttpPost]
            public IActionResult Add(Employee employee)
            {
                _employeeService.Add(employee);
                return Ok("Employee Added Successfully");
            }

            // PUT: api/Employee
            [HttpPut]
            public IActionResult Update(Employee employee)
            {
                _employeeService.Update(employee);
                return Ok("Employee Updated Successfully");
            }

            // DELETE: api/Employee/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                _employeeService.Delete(id);
                return Ok("Employee Deleted Successfully");
            }
        }
    }



        