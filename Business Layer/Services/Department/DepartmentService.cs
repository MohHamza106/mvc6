using Business_Layer.DTO.Department;
using Data_Aceess_Layer.Entites.Departments;
using Data_Aceess_Layer.Presistance.Repostories.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.Department
{
    public class DepartmentService : iDepartmentServices
    {
        private readonly iDepartmentReporstory _departmentReporstory;

        public DepartmentService(iDepartmentReporstory departmentReporstory)
        {
            _departmentReporstory = departmentReporstory;
        }

        public int CreateDepartment(DepartmentToCreateDTO department)
        {
            var deparmtentCreated = new Departments()
            {
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreationDate = department.CreationDate,
                LastModifiedby = 1,
                createdbt = 1,
                LastModifiedat = DateTime.UtcNow,
            };
            int rowsaffected = _departmentReporstory.AddT(deparmtentCreated);
            return rowsaffected;
        }

        public IEnumerable<DepartmentDetailsToReturnDto> GetAllDepartments()
        {
            // var departments = _departmentReporstory.GetAll();//Ienurmable of department 
            // // DEpartment ==> DepartmentToReturnDto 
            //foreach (var department in departments)
            // {
            //     yield return new DepartmentDetailsToReturnDto()
            //     {
            //         Description = department.Description,
            //         CreationDate = department.CreationDate,
            //         Code = department.Code,
            //         Id = department.Id,
            //         Name = department.Name,
            //     };
            // }
            var department = _departmentReporstory.GetAllQuerable().Where(D=>!D.IsDeleted).Select(department => new DepartmentDetailsToReturnDto
            {
                Description = department.Description,
                CreationDate = department.CreationDate,
                Code = department.Code,
                Id = department.Id,
                Name = department.Name
            }).AsNoTracking().ToList();
            return department;
          
        }

        //public DepartmentDetailsToReturnDto? GetDeparmentbyId(int id)
        //{
        //    var department = _departmentReporstory.GetByID(id);
        //    if(department != null)
        //    {
        //        return new DepartmentDetailsToReturnDto()
        //        {
        //            Code = department.Code,
        //            Id = department.Id,
        //            Name = department.Name,
        //            createdon = department.createdon,
        //            createdbt = department.createdbt,
        //            CreationDate = department.CreationDate,
        //            LastModifiedat = department.LastModifiedat,
        //            LastModifiedby = department.LastModifiedby,
        //            Description = department.Description,
        //            IsDeleted = department.IsDeleted,

        //        };
        //    }
        //}

        public int UpdateDepartment(DepartmentToUpdateDTO department)
        {
            var deparmtentUpdate = new Departments()
            {
                Id = department.Id,
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreationDate = department.CreationDate,
                LastModifiedby = 1,
                createdbt = 1,
                LastModifiedat = DateTime.UtcNow,
            };
            return _departmentReporstory.updateT(deparmtentUpdate);

        }
        public bool DeleteDepartment(int id)
        {
            var department = _departmentReporstory.GetByID(id);
            if (department != null)
            {
                int rowsAffected = _departmentReporstory.DeleteT(department);
                return rowsAffected > 0;
            }
            return false;
        }

        public DepartmentDetailsToReturnDto? GetDepartmentById(int id)
        {
            var department = _departmentReporstory.GetByID(id);
            if (department != null)
            {
                return new DepartmentDetailsToReturnDto()
                {
                    Code = department.Code,
                    Id = department.Id,
                    Name = department.Name,
                    createdon = department.createdon,
                    createdbt = department.createdbt,
                    CreationDate = department.CreationDate,
                    LastModifiedat = department.LastModifiedat,
                    LastModifiedby = department.LastModifiedby,
                    Description = department.Description,
                    IsDeleted = department.IsDeleted,

                };
            }
            return null!;
        }
    }
}
