
using Microsoft.AspNetCore.Mvc;
using IBASEmployeeService.Models;

namespace IBASEmployeeService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;

        private static readonly List<Employee> Employees = new()
        {
            new Employee()
            {
                Id = "21",
                Name = "Mette Bangsbo",
                Email = "meba@ibas.dk",
                Department = new Department()
                {
                    Id = 1,
                    Name = "Salg"
                }
            },
            new Employee()
            {
                Id = "22",
                Name = "Hans Merkel",
                Email = "hame@ibas.dk",
                Department = new Department()
                {
                    Id = 2,
                    Name = "Support"
                }
            },
            new Employee()
            {
                Id = "42",
                Name = "Bo Madsen",
                Email = "boma@ibas.dk",
                Department = new Department()
                {
                    Id = 6,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "62",
                Name = "Hanne Mokab",
                Email = "hamo@ibas.dk",
                Department = new Department()
                {
                    Id = 6,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "82",
                Name = "Anders Von",
                Email = "anvo@ibas.dk",
                Department = new Department()
                {
                    Id = 6,
                    Name = "It"
                }
            },
            new Employee()
            {
                Id = "222",
                Name = "Birte",
                Email = "birt@ibas.dk",
                Department = new Department()
                {
                    Id = 8,
                    Name = "Kantinen"
                }
            },
            new Employee()
            {
                Id = "226",
                Name = "Jonna",
                Email = "jonn@ibas.dk",
                Department = new Department()
                {
                    Id = 18,
                    Name = "Kantinen"
                }
            },
            new Employee()
            {
                Id = "23",
                Name = "Karsten Mikkelsen",
                Email = "kami@ibas.dk",
                Department = new Department()
                {
                    Id = 2,
                    Name = "Support"
                }
            }
        };

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> Get()
        {
            return Employees;
        }

        [HttpGet("GetDepartment/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> GetByDepartmentId(int departmentId)
        {
            var employees = Employees.Where(
                e => e.Department != null &&
                     e.Department.Id == departmentId);

            if (!employees.Any())
            {
                return NotFound();
            }

            return Ok(employees);
        }
    }
}