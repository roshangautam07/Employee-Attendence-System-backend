using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using dotnet.Models;
using dotnet.Payload.Request;
using dotnet.Payload.Response;
using dotnet.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        public IEmployeeService Service;

        public EmployeeApiController(IEmployeeService Service)
        {
            this.Service = Service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                Service.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var user = Service.GetOne(id);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, 
                    new Error($"requested id {id} is not found ",StatusCodes.Status404NotFound.ToString()));
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]  EmployeeRequest employeeRequest)
        {
            var emp = new Employee();
            emp.firstName = employeeRequest.firstName;
            emp.middleName = employeeRequest.lastName;
            emp.lastName = employeeRequest.lastName;
            emp.contact = employeeRequest.contact;
            emp.gender = employeeRequest.gender;
            emp.address = employeeRequest.address;
            emp.isActive = employeeRequest.isActive;
            var context = new ValidationContext(emp, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(emp,context,result,true);
            if (result.Count == 0)

            {
                Service.AddEmployee(emp);
                return Ok(
                    new Success("Successfully saved", StatusCodes.Status200OK.ToString()));
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            var emp = new Employee();
            emp.firstName = employeeRequest.firstName;
            emp.middleName = employeeRequest.lastName;
            emp.lastName = employeeRequest.lastName;
            emp.contact = employeeRequest.contact;
            emp.gender = employeeRequest.gender;
            emp.address = employeeRequest.address;
            emp.isActive = employeeRequest.isActive;
            Service.UpdateEmployee(id,emp);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("/toggle/{id:int}")]
        public IActionResult ToggleStatus(int id, Employee employee)
        {
            Service.EmployeeStatusToggle(id,employee);
            return StatusCode(StatusCodes.Status200OK,
                new Success("Status Updated", StatusCodes.Status200OK.ToString()));
        }
        

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}