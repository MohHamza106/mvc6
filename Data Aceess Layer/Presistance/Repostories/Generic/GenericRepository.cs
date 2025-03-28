using Data_Aceess_Layer.Entites;
using Data_Aceess_Layer.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Aceess_Layer.Presistance.Repostories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T  : Model_Base
    {
        private readonly ApplicationDbContext _dbcontext;
        public GenericRepository(ApplicationDbContext dbContext) // ask clr to create object from ApplicationDbContext 
        {
            _dbcontext = dbContext;
        }
        public int AddT(T entity)
        {
            _dbcontext.Set<T>().Add(entity);//saved locally
            return _dbcontext.SaveChanges(); // apply remotly 
        }

        public int DeleteT(T entity)
        {
            //_dbcontext.Set<T>().Remove(entity);
            //return _dbcontext.SaveChanges();
            entity.IsDeleted = true;
            _dbcontext.Set<T>().Update(entity);
            return _dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool AsnoTracking = true)
        {
            //Isdeleted ==> false 
            if (AsnoTracking)
            {
                return _dbcontext.Set<T>().Where(X=>!X.IsDeleted).AsNoTracking().ToList(); //ditached 
            }
            return _dbcontext.Set<T>().Where(X => !X.IsDeleted).ToList(); // unchanged
        }

        public IQueryable<T> GetAllQuerable()
        {
            return _dbcontext.Set<T>();
        }

        public T GetByID(int id)
        {
            //return _dbcontext.Departments.Local.FirstOrDefault(D=>D.Id == id);
            return _dbcontext.Set<T>().Find(id);  // search local , incase found return it 
        }

        public int updateT(T entity)
        {
            _dbcontext.Set<T>().Update(entity); // modify
            return _dbcontext.SaveChanges();
        }
        public IEnumerable<T> GetAllEnumerable()
        {
            return _dbcontext.Set<T>();
        }
    }
}
