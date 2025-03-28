using Business_Layer.DTO.Department;
using Data_Aceess_Layer.Entites.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Department
{
    public interface iDepartmentServices
    {
        IEnumerable<DepartmentDetailsToReturnDto> GetAllDepartments();
        public DepartmentDetailsToReturnDto? GetDepartmentById(int id);
        int CreateDepartment(DepartmentToCreateDTO department);
        int UpdateDepartment(DepartmentToUpdateDTO department);
        bool DeleteDepartment(int id);
        
    }
}
