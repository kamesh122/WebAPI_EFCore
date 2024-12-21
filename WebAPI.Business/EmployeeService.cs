using WebAPI.Business.Interfaces;
using WebAPI.Data.Repository.Interfaces;
using WebAPI.Model;

namespace WebAPI.Business
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
                employeeRepository = _employeeRepository;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepository.GetEmployees();
        }
    }
}
