using Data_Aceess_Layer.Entites;

using Data_Aceess_Layer.Presistance.Repostories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Repostories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
      
    }
}
