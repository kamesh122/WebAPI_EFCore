using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Interfaces;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService employeeService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService _employeeService, IConfiguration configuration, ILogger<EmployeeController> logger)
        {
            employeeService = _employeeService;
            _configuration = configuration;
            _logger = logger;   
        }

        [HttpGet]
        public IActionResult Employees()
        {
             
                _logger.LogInformation("Starting application...");                
            

            List<string> result = new List<string>()
            {
                _configuration["connectionstring"],
                _configuration["rediscache"]
            };

            var Emp = employeeService.GetEmployees();
            return Ok(Emp);
        }


    }
}
