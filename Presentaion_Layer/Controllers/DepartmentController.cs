using Business_Layer.DTO.Department;
using Business_Layer.Services.Department;
using Microsoft.AspNetCore.Mvc;
using Presentaion_Layer.ViewModels;

namespace Presentaion_Layer.Controllers
{
    public class DepartmentController : Controller
    {
        // departmentcontrller : inheritance [its controller]
        // departmentcontroller : conposition [has a department service]

        private readonly iDepartmentServices _departmentservices;
        private readonly ILogger<DepartmentController>_logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(iDepartmentServices departmentServices , ILogger<DepartmentController> logger , IWebHostEnvironment environment) 
        {
           _departmentservices = departmentServices;
            _logger = logger;
            _environment = environment;
        }
        //action => master action 
        // Get : baseurl / Department/Index

        // viewStorage ==> viewdata , viewbag ==> deal with the same storage
        // Dictionary 
        //extra data 
        // 1] send data from action in controller to view
        // 2] send data from view to partial view 
        // 3] send data from view to layout 
        
        // view data ==> .net 3.5
        // view bag ==> .net 4.0 

        // Temp data ==> .net 3.5 === send data from request to another request [from action to another]
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["message"] = "Hello from View Data ";
            var department = _departmentservices.GetAllDepartments();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentViewModel  departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);
            }
            var message = string.Empty;
            try
            {
                //_departmentservices.CreateDepartment(new DepartmentToCreateDTO);
                var result = _departmentservices.CreateDepartment(new DepartmentToCreateDTO()
                {
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreationDate = departmentVM.CreationDate,
                });

                if (result> 0)
                {
                    TempData["message"] = "Department is created";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department cant be created";
                    TempData["message"] = message;
                    ModelState.AddModelError(string.Empty, message);
                    return View(departmentVM);
                }

            }
            catch (Exception ex)
            {
                // log exception 
                _logger.LogError(ex,ex.Message);
                if ( _environment.IsDevelopment())
                {
                    message= ex.Message;
                    return View(departmentVM);
                }
                else
                {
                    message = " Department cant be created";
                    return View("error",message);
                }
            }
           
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();//400
            var department = _departmentservices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();//404
            return View(department);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentservices.GetDepartmentById(id.Value);
            if (department is null)
                return NotFound();
            return View(new DepartmentViewModel
            {
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description,
            });
        }

        [HttpPost]
        public IActionResult Edit(int id , DepartmentViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }
            var message = string.Empty;
            try
            {
                _departmentservices.UpdateDepartment(new DepartmentToUpdateDTO()
                {
                    Id =id, 
                    Name = editViewModel.Name,
                    Code = editViewModel.Code,
                    CreationDate = editViewModel.CreationDate,
                    Description = editViewModel.Description,

                });
                return View(editViewModel);
            }
            catch (Exception ex)
            {
                message = _environment.IsDevelopment() ? ex.Message : "Department Can't Be Updated";
            }
            return View(editViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var department = _departmentservices.GetDepartmentById(id.Value);
            if (department is null) return NotFound();
            return View(department);

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmentservices.DeleteDepartment(id);
            return View(nameof(Index));
        }
    }
}
