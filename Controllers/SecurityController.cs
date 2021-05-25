using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using dotnet.Helper;
using dotnet.Models;
using dotnet.Payload.Response;
using dotnet.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace dotnet.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController:ControllerBase
    {
        public IEmployeeService Service;
        private IConfiguration _config = null;
        private string _securityKey = "";
        private string _issuer = "";
        private string _audience = "";

        public SecurityController(IConfiguration _config,IEmployeeService Service)
        {
            this._config = _config;
            _securityKey = _config["Token:SecurityKey"];
            _issuer = _config["Token:Issuer"];
            _audience=_config["Token:Audience"];
            this.Service = Service;
        }
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody] Users users)
        {
            if (users.userName.Equals("") && users.password.Equals(""))
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    new Error("Username and password is required",
                        StatusCodes.Status401Unauthorized.ToString()));
            }
            
            if (Service.auth(users).Any())
            {
                Token t = new Token();
                string token = new TokenUtils(_config).GenerateToken(users.userName);
                t.token = token;
                return Ok(t);
            }
            return StatusCode(StatusCodes.Status401Unauthorized, 
                new Error("Provided credential is incorrect",
                    StatusCodes.Status401Unauthorized.ToString()));
        }
        
        
    }
}