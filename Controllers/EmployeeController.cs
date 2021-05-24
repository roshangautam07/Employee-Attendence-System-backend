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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace dotnet.Controllers
{
    public class EmployeeController:Controller
    {
        private EmployeeDbContext _context = null;

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
    }
}