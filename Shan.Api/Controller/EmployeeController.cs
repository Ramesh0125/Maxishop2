using Microsoft.AspNetCore.Mvc;
using AdoNetApi.Models;
using AdoNetApi.IService;


namespace AdoNetApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Get All Employees

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployees();

            return Ok(employees);
        }

        // Get Employee By Id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployeeById(int Empid)
        {
            var employee = await _employeeService.GetEmployeeById(Empid);

            if (employee == null)
            {
                return NotFound("Employee Not found");
            }

            return Ok (employee);

        }

        // Insert Employee

        [HttpPost]

        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
            var id = await _employeeService.InsertEmployee(employee);

            return Ok(id);
            
        }

        // Update Employee

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(int Empid, Employee employee)
        {
            var result = await _employeeService.UpdateEmployee(Empid, employee);

            if (result)
            {
                return NotFound("Employee not found");
            }
                
            return Ok("Employee updated successfully");

        }

        // Delete Employee

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Empid)
        {
            var result = await _employeeService.DeleteEmployee(Empid);

            if (result)
            {
                return NotFound("Employee not found");
            }  

            return Ok("Employee deleted successfully");
        }

    } 

}
