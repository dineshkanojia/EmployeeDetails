using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class RepositoryEmployee : IRepository<Employee>
    {
        ApplicationDBContext _dbContext;

        public RepositoryEmployee(ApplicationDBContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public async Task<Employee> Create(Employee _object)
        {
            var obj = await _dbContext.Employees.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Employee _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
        {
            try
            {
                var employee = _dbContext.Employees.Include(e => e.RoleMapping).ThenInclude(r => r.Roles).ToList();

                return employee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Employee GetById(int Id)
        {
            var emp = _dbContext.Employees.Where(x => x.IsDelete == false && x.Id == Id).FirstOrDefault();
            //  emp.Roles = GetRole(emp.Id);
            return emp;
        }

        public void Update(Employee _object)
        {
            try
            {
                _dbContext.Entry(_object).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Roles GetRole(int userId)
        {
            try
            {
                var rolesmap = _dbContext.RoleMapping.FirstOrDefault(r => r.UserId == userId);
                var role = _dbContext.Roles.FirstOrDefault(r => r.Id == rolesmap.RoleId);

                return role;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

