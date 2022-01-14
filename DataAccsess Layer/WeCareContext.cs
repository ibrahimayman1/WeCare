using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class WeCareContext : IdentityDbContext
    {
        
        public WeCareContext(DbContextOptions<WeCareContext> options) : base(options)
        {

        }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Distructs> Distructs { get; set; }
        public virtual DbSet<Drugs> Drugs { get; set; }

        public virtual DbSet<DrugsGroups> DrugsGroups { get; set; }
        public virtual DbSet<Interests> Interests { get; set; }
        public virtual DbSet<VaccineTypes> VaccineTypes { get; set; }


    }
}
