using System;
using System.Collections.Generic;
using System.Linq;
using dotnet.DataAccess;
using dotnet.Models;
using dotnet.Payload.Request;
using dotnet.Payload.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Services
{
    public class EmployeeServiceImpl:IEmployeeService
    {
        public EmployeeDbContext db;

        public EmployeeServiceImpl(EmployeeDbContext db)
        {
            this.db = db;
        }
        public List<Employee> GetAllEmployees()
        {
            return db.employee
                .Include(a => a.attendences)
                .ToList<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            db.employee.Add(employee);
            db.SaveChanges();
        }

        public Employee GetOne(string id)
        {
            Employee objEmp = new Employee();  
            int ID = Convert.ToInt32(id); 
            objEmp = db.employee.Find(ID);
            return objEmp;
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            var emp = db.employee.Find(id);
            emp.firstName = employee.firstName;
            emp.middleName = employee.middleName;
            emp.lastName = employee.lastName;
            emp.gender = employee.gender;
            emp.contact = employee.contact;
            emp.address = employee.address;
            emp.dob = employee.dob;
            emp.isActive = employee.isActive;
            db.employee.Update(emp);
            db.SaveChanges();
        }

        public void EmployeeStatusToggle(int id, Employee employee)
        {
            var emp = db.employee.Find(id);
            emp.isActive = employee.isActive;
            db.employee.Update(emp);
            db.SaveChanges();
            
        }

        public void AddAttendance(Attendance attendance)
        {
            db.attendance.Add(attendance);
            db.SaveChanges();
        }
    }
}