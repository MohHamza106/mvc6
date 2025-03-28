using Business_Layer.DTO.Department;
using Business_Layer.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeToReturnDTO> GetAllEmployee();
        public EmployeeDetailsReturnDTO? GetEmployeeById(int id);
        int CreateEmployee(EmployeeToCreateDTO employee);
        int UpdateEmployee(EmployeeToUpdateDTO employee);
        bool Deleteemployee(int id);
    }
}
