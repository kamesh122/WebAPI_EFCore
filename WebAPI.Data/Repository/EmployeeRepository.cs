using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Context;
using WebAPI.Data.Repository.Interfaces;
using WebAPI.Model;

namespace WebAPI.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public DatabaseContext _databaseContext;
        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return _databaseContext.Employees.Include(x=>x.Department).AsEnumerable();
             
        }
    }
}
