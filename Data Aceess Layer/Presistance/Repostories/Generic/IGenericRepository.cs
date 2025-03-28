using Data_Aceess_Layer.Entites;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Repostories.Generic
{
    public interface IGenericRepository<T> where T : Model_Base
    {
        IEnumerable<T> GetAll(bool AsnoTracking = true);
        IQueryable<T> GetAllQuerable();
        IEnumerable<T> GetAllEnumerable();
        T GetByID(int id);
        int AddT(T entity);
        int updateT(T entity);
        int DeleteT(T entity);
    }
}
