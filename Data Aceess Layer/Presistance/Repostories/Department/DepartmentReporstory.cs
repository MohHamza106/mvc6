using Data_Aceess_Layer.Entites;
using Data_Aceess_Layer.Presistance.Data;
using Data_Aceess_Layer.Presistance.Repostories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data_Aceess_Layer.Presistance.Repostories.Department
{
    // Database ==> Repository ==> services ==> controller 
    public class DepartmentReporstory : GenericRepository<Departments> , iDepartmentReporstory
    {
        public DepartmentReporstory(ApplicationDbContext dbContext):base(dbContext) 
        {
            
        }
    }
}
