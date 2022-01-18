using bussinesslayer.Interface;
using Motim_Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussinesslayer
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<City> city { get; }
        IGenericRepository<Distructs> Distructs { get; }
        
              IGenericRepository<Drugs> Drugs { get; }
        IGenericRepository<DrugsGroups> DrugsGroups { get; }
      
            IGenericRepository<Interests> Interests { get; }
      
             IGenericRepository<Vaccancies> Vaccancies { get; }
        
            IGenericRepository<VaccineTypes> VaccineTypes { get; }
        
             IGenericRepository<Customer> Customer { get; }
        int Complete();
    }
}
