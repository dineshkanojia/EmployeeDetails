using DataLayer.Interface;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employee;

        public EmployeeService(IRepository<Employee> employee)
        {
            _employee = employee;
        }

        //Get Person Details By Person Id
        public IEnumerable<Employee> GetPersonByUserId(int UserId)
        {
            return _employee.GetAll().Where(x => x.Id == UserId).ToList();
        }


        //GET All Perso Details 
        public IEnumerable<Employee> GetAllPersons()
        {
            try
            {
                return _employee.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get Person by Person Name
        public Employee GetPersonByUserName(string UserName)
        {
            return _employee.GetAll().Where(x => x.UserName == UserName).FirstOrDefault();
        }


        public Employee GetPersonByEmail(string userEmail)
        {
            return _employee.GetAll().FirstOrDefault(e => e.Email == userEmail);
        }

        //Add Person
        public async Task<Employee> AddPerson(Employee employee)
        {
            return await _employee.Create(employee);
        }

        //Delete Person 
        public bool DeletePerson(string UserName)
        {

            try
            {
                var DataList = _employee.GetAll().Where(x => x.UserName == UserName).ToList();
                foreach (var item in DataList)
                {
                    _employee.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }

        //Update Person Details
        public bool UpdatePerson(Employee employee)
        {
            try
            {
                var emp = _employee.GetAll().Where(x => x.Id == employee.Id).FirstOrDefault();
                if (emp != null)
                {
                    emp.IsDelete = employee.IsDelete;
                    emp.Id = employee.Id;
                    emp.Email = employee.Email;
                    emp.UserName = employee.UserName;
                    emp.Password = employee.Password;
                    emp.Address1 = employee.Address1;
                    emp.Address2 = employee.Address2;
                    emp.Photo = employee.Photo;
                    emp.Desgination = employee.Desgination;
                    emp.DOB = employee.DOB;
                    emp.FirstName = employee.FirstName;
                    emp.LastName = employee.LastName;
                    emp.Mobile = employee.Mobile;
                    emp.Postcode = employee.Postcode;
                    emp.Status = employee.Status;
                    _employee.Update(emp);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

    }
}
