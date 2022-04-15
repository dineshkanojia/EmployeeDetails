using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        private readonly IRepository<Employee> _Employee;

        public EmployeeController(IRepository<Employee> Employee, EmployeeService EmployeeService)
        {
            _employeeService = EmployeeService;
            _Employee = Employee;

        }

        [HttpPost("AddEmployee")]
        [Authorize(Roles = "Admin, Employee")]
        public async Task<Object> AddPerson([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.AddPerson(employee);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        [HttpDelete("DeleteEmployee")]
        //[Authorize(Roles = "Admin")]
        public bool DeletePerson(int Id)
        {
            try
            {
                _employeeService.DeletePerson(Id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost("UpdateEmployee")]
       // [Authorize(Roles = "Admin, Employee")]
        public bool UpdatePerson(Employee employee)
        {
            try
            {
                _employeeService.UpdatePerson(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet("GetAllEmployeeByName")]
       // [Authorize(Roles = "Employee")]
        public Object GetAllPersonByName(string Username)
        {
            var data = _employeeService.GetPersonByUserName(Username);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("GetAllEmployeeByEmail")]
        [Authorize(Roles = "Admin, Employee")]
        public Object GetAllPersonByNamGetAllEmployeeByEmail(string Useremail)
        {
            var data = _employeeService.GetPersonByEmail(Useremail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("GetAllEmployee")]
        public Object GetAllPersons()
        {
            var data = _employeeService.GetAllPersons();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
