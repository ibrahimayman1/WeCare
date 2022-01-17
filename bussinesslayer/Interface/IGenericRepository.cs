using Motim_Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bussinesslayer.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
       
        public void Delete(int Id);
      void Update( T entity);
        //T Search(string name);
         T Search(Expression<Func<T, bool>> Match);
       
    }
}
