using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        private readonly IRepository<Employee> _Employee;

        private IConfiguration _config;

        public LoginController(IRepository<Employee> Employee, EmployeeService EmployeeService, IConfiguration config)
        {
            _employeeService = EmployeeService;
            _Employee = Employee;
            _config = config;

        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(EmployeeLogin employeeLogin)
        {
            var user = Authenticate(employeeLogin);

            if (user.ResponseStatus)
            {
                var token = GeneerateToken(user);
                return Ok(token);
            }
            return NotFound(user.ErrorMessage);
        }

        private string GeneerateToken(EmployeeViewModel employeeLogin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,employeeLogin.UserName ),
                new Claim(ClaimTypes.Email,employeeLogin.Email),
                new Claim(ClaimTypes.Surname,employeeLogin.LastName),
                new Claim(ClaimTypes.Name,employeeLogin.FirstName),
                new Claim(ClaimTypes.Role,employeeLogin.RoleName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(100),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private EmployeeViewModel Authenticate(EmployeeLogin employeeLogin)
        {
            var user = _employeeService.GetPersonByEmail(employeeLogin.Email);
            var userModel = new EmployeeViewModel();
            if (user != null && !string.IsNullOrEmpty(user.UserName))
            {
                if (user.Password != employeeLogin.Password)
                {
                    userModel.ResponseStatus = false;
                    userModel.ErrorCode = "401";
                    userModel.ErrorMessage = "Incorrect password.";
                    return userModel;
                }
                else
                {
                    userModel.Email = user.Email;
                    userModel.FirstName = user.FirstName;
                    userModel.LastName = user.LastName;
                    userModel.RoleName = user.RoleMapping.FirstOrDefault(r => r.UserId == user.Id).Roles.RoleName;
                    userModel.UserName = user.UserName;
                    return userModel;
                }
            }
            else
            {
                userModel.ResponseStatus = false;
                userModel.ErrorCode = "401";
                userModel.ErrorMessage = "Incorrect email.";
                return userModel;
            }
            return userModel;
        }
    }
}
