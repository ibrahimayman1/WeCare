using bussinesslayer.Interface;
using bussinesslayer.Repository;
using Motim_Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussinesslayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeCareContext   _context;
        public IGenericRepository<City> city { get; private set; }

       public IGenericRepository<Distructs> Distructs { get; private set; }
        public IGenericRepository<Drugs> Drugs { get; private set; }

           public IGenericRepository<DrugsGroups> DrugsGroups { get; private set; }
      
                public IGenericRepository<Interests> Interests { get; private set; }
        
                 public IGenericRepository<Vaccancies> Vaccancies { get; private set; }
      
            public IGenericRepository<VaccineTypes> VaccineTypes { get; private set; }
        public UnitOfWork(WeCareContext context)
        {
            _context = context;
          
            city = new GenericRepository<City>(_context);
            Distructs= new GenericRepository<Distructs>(_context);
            Drugs= new GenericRepository<Drugs>(_context);
            DrugsGroups= new GenericRepository<DrugsGroups>(_context);
            Interests= new GenericRepository<Interests>(_context);
            Vaccancies= new GenericRepository<Vaccancies>(_context);
            VaccineTypes = new GenericRepository<VaccineTypes>(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
