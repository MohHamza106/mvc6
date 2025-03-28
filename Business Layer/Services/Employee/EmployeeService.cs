using Business_Layer.DTO.Employee;
using Data_Aceess_Layer.Entites;
using Data_Aceess_Layer.Presistance.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EmployeeModel = Data_Aceess_Layer.Employee;

namespace Business_Layer.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)  // ask clr to create insistance 
        {
            _employeeRepository = employeeRepository;
        }

        public int CreateEmployee(EmployeeToCreateDTO employeeDto)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.phoneNumber,
                HiringDate = employeeDto.HiringDate,
                gender = employeeDto.gender,
                EmployeeType = employeeDto.EmployeeType,
                createdbt = 1,
                LastModifiedby = 1,
                LastModifiedat = DateTime.UtcNow
            };
                return _employeeRepository.AddT(employee); // number of rows affected 
        }    

        public bool Deleteemployee(int id)
        {
            var employee = _employeeRepository.GetByID(id);
            if (employee != null) // EMployee is not null 

            return _employeeRepository.DeleteT(employee) > 0;// rows affected > 0 ==> true 
            return false;
        }

        public IEnumerable<EmployeeToReturnDTO> GetAllEmployee()
        {
           var query =  _employeeRepository.GetAllQuerable().Where(E=>!E.IsDeleted).Select(employee => new EmployeeToReturnDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                gender=employee.gender.ToString(),
                EmployeeType = employee.EmployeeType.ToString(),
                IsActive = employee.IsActive,
               Department = employee.Departments.Name,
               
            });


            var count = query.Count();
            var firstEmployee = query.FirstOrDefault();
            var employees = query.ToList() ;
            return query;
        }

        public EmployeeDetailsReturnDTO? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetByID(id);
            if (employee != null)
            {
                return new EmployeeDetailsReturnDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Salary = employee.Salary,
                    gender = employee.gender.ToString(),
                    EmployeeType = employee.EmployeeType.ToString(),
                    IsActive = employee.IsActive,
                    createdbt = employee.createdbt,
                    createdon = employee.createdon,
                    LastModifiedat = employee.LastModifiedat,
                    LastModifiedby = employee.LastModifiedby,
                    IsDeleted = employee.IsDeleted,
                    Address = employee.Address,
                    HiringDate = employee.HiringDate,
                    PhoneNumber = employee.PhoneNumber,
                };
            }
            return null;
        }

        public int UpdateEmployee(EmployeeToUpdateDTO employeeDto)
        {
            EmployeeModel employee = new EmployeeModel()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                Salary = employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                HiringDate = employeeDto.HiringDate,
                gender = employeeDto.gender ,
                EmployeeType = employeeDto.EmployeeType,
                createdbt = 1,
                LastModifiedby = 1,
                LastModifiedat = DateTime.UtcNow
                 
            };
           return _employeeRepository.updateT(employee); // number of rows affected 
        }
    }

       
}

