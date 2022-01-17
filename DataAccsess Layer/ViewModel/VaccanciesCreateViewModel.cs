using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess_Layer.ViewModel
{
    public class VaccanciesCreateViewModel
    {
        public string VaccineTittle { get; set; }

        public int VaccineMonths { get; set; }
        public int VaccineTypeID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
