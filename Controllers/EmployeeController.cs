using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;
using dotnet.Models;
using dotnet.Payload.Response;
using dotnet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace dotnet.Controllers
{
    [Authorize]
    [EnableCors("MyPolicy")]
    public class EmployeeController : Controller
    {
        private EmployeeDbContext _context = null;
        public IEmployeeService Service;

        public EmployeeController(EmployeeDbContext _context)
        {
            this._context = _context;
        }

        public IActionResult CheckConnection()
        {
            if (_context.Database.CanConnect())
            {
                return Ok("Connect");
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Fail to connect");
        }

        public IActionResult ReadAll()
        {
            return Json(
                _context.employee
                    .Include(a => a.attendences)    
                    .ToList<Employee>()
                    .Any()
                    ? (object) _context.employee
                    : StatusCode(StatusCodes.Status404NotFound,
                        new Error("No data found",StatusCodes.Status204NoContent.ToString())));
        }
        
         public IActionResult GetAllEmployee()
                {
                    return Json(
                        _context.employee   
                            .ToList<Employee>()
                            .Any()
                            ? (object) _context.employee
                            : StatusCode(StatusCodes.Status404NotFound,
                                new Error("No data found",StatusCodes.Status204NoContent.ToString())));
                    // return Json(
                    //     Service.GetAllEmployees());
                }


        public IActionResult Get(string id)
        {
            Employee objEmp = new Employee();
            int ID = Convert.ToInt32(id);
            objEmp = _context.employee.Find(ID);
            if (objEmp == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, 
                    new Error($"requested id {ID} is not found ",StatusCodes.Status404NotFound.ToString()));
            }
             return Ok(objEmp);
        }

        public IActionResult save([FromBody] Employee employee)
        {
            var context = new ValidationContext(employee, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(employee,context,result,true);
            if (result.Count==0)
                
            {
            _context.employee.Add(employee);
            _context.SaveChanges();
            return Json(
                StatusCode(StatusCodes.Status200OK,
                    new Success("Successfully saved",StatusCodes.Status200OK.ToString())));
            }else{

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        public IActionResult saveAttendance([FromBody] Attendance attendance)
        {
           
            var context = new ValidationContext(attendance, null, null);
            var result = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(attendance,context,result,true);
            if (result.Count == 0)

            {

                _context.attendance.Add(attendance);
                _context.SaveChanges();
                return Json(
                    _context.attendance.ToList<Attendance>());
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        public IActionResult updateEmployee(int id, [FromBody] Employee employee)
        {
            var emp = _context.employee.Find(id);
            emp.firstName = employee.firstName;
            emp.middleName = employee.middleName;
            emp.lastName = employee.lastName;
            emp.gender = employee.gender;
            emp.contact = employee.contact;
            emp.address = employee.address;
            emp.dob = employee.dob;
            emp.isActive = employee.isActive;
            _context.employee.Update(emp);
            _context.SaveChanges();
            return Json(emp);
        }

        public IActionResult toggleStatus(int id, [FromBody] Employee employee)
        {
            var emp = _context.employee.Find(id);
            emp.isActive = employee.isActive;
            _context.employee.Update(emp);
            _context.SaveChanges();
            return Json(emp);
        }

        public IActionResult GetAttendanceByEmployee(int id)
        {
            return Json((from a in _context.attendance
                where a.employeeId == id
                select a).ToList<Attendance>());
        }
    }
}