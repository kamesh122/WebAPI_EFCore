using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Business.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
    }
}
