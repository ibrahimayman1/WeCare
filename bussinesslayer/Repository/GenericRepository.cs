using bussinesslayer.Interface;
using Microsoft.EntityFrameworkCore;
using Motim_Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bussinesslayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected WeCareContext _context;

        public GenericRepository(WeCareContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            
                 _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete(int Id)
        {

            T Object = GetById(Id);
            
            _context.Set<T>().Remove(Object);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var entity= _context.Set<T>().Find(id);

            return _context.Set<T>().Find(id);
        }

        //public T Search(string name)
        //{
        //    return  _context.Set<T>().Where(Func())
        //}

        public void Update(T entity )
        {
            
            _context.Entry(entity).State=EntityState.Modified;
            _context.SaveChanges();

        }
        public T Search(Expression<Func<T, bool>> Match  )
        {
                    
            return _context.Set<T>().SingleOrDefault(Match);
        }

       
    }
}
