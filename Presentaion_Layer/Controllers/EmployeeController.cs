using Business_Layer.DTO.Employee;
using Business_Layer.Services.Employee;
using Data_Aceess_Layer.Entites.common.Enums;
using Data_Aceess_Layer.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentaion_Layer.ViewModels;
using Business_Layer.Services.Department;
using Microsoft.AspNetCore.Mvc.Rendering;
using Business_Layer.DTO.Department;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Presentaion_Layer.Controllers
{
    public class EmployeeController : Controller
    {
        // employeecontrller : inheritance [its controller]
        // employeecontroller : conposition [has a department service]

        private readonly IEmployeeService _employeeservices;
        private readonly ILogger<EmployeeController>_logger;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeServices , ILogger<EmployeeController> logger , IWebHostEnvironment environment ) 
        {
           _employeeservices = employeeServices;
            _logger = logger;
            _environment = environment;
        }
        //action => master action 
        // Get : baseurl / Employee/Index
        [HttpGet]
        public IActionResult Index()
        {
            var employee = _employeeservices.GetAllEmployee();
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create([FromServices]
            iDepartmentServices departmentServices)
        {
            var departments = departmentServices.GetAllDepartments();
            var items = new SelectList(departments,
                nameof(DepartmentDto.Id)
                ,nameof(DepartmentDto.Name) );

            ViewBag.Departments = items;

            return View();
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ValidateAntiForgeryToken] // action filter 
        public IActionResult Create(EmployeeToCreateDTO employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeDto);
            }
            var message = string.Empty;
            try
            {
               _employeeservices.CreateEmployee(employeeDto);
                var result = _employeeservices.CreateEmployee(employeeDto);

                if (result> 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Employee cant be created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(employeeDto);
                }

            }
            catch (Exception ex)
            {
                // log exception 
                _logger.LogError(ex,ex.Message);
                if ( _environment.IsDevelopment())
                {
                    message= ex.Message;
                    return View(employeeDto);
                }
                else
                {
                    message = " Employee cant be created";
                    return View("error",message);
                }
            }
           
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();//400
            var employee = _employeeservices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();//404
            return View(employee);

        }
        [HttpGet]
        public IActionResult Edit(int? id , [FromServices]
            iDepartmentServices departmentServices)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeservices.GetEmployeeById(id.Value);
            if (employee is null)
                return NotFound();

            var departments = departmentServices.GetAllDepartments();
            var items = new SelectList(departments,
                nameof(DepartmentDto.Id)
                , nameof(DepartmentDto.Name));
                ViewBag.Departments = items;

            return View(new EmployeeToUpdateDTO
            {
                EmployeeType = Enum.TryParse<EmployeeType>(employee.EmployeeType, out var empType )? empType : default,
                gender = Enum.TryParse<Gender>(employee.gender, out var _gender) ? _gender : default,
                Name = employee.Name,
                Email = employee.Email,
                Address = employee.Address,
                Age = employee.Age,
                PhoneNumber = employee.PhoneNumber,
                IsActive = employee.IsActive,
                Id = employee.Id,
                Salary = employee.Salary,
                
            });
           
            
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id , EmployeeToUpdateDTO EmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(EmployeeDto);
            }
            var message = string.Empty;
            try
            {
                _employeeservices.UpdateEmployee(EmployeeDto);
                return View(EmployeeDto);
            }
            catch (Exception ex)
            {
                message = _environment.IsDevelopment() ? ex.Message : "Employee Can't Be Updated";
            }
            return View(EmployeeDto);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var employee = _employeeservices.GetEmployeeById(id.Value);
            if (employee is null) return NotFound();
            return View(employee);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _employeeservices.Deleteemployee(id);
            return View(nameof(Index));
        }
    }
}
