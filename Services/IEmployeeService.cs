using System;
using System.Collections.Generic;
using dotnet.Models;
using dotnet.Payload.Request;
using dotnet.Payload.Response;

namespace dotnet.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);

        public void AddAttendance(Attendance attendance);
        public Employee GetOne(string id);

        public void UpdateEmployee(int id, Employee employee);

        public void EmployeeStatusToggle(int id, Employee employee);
    }
}