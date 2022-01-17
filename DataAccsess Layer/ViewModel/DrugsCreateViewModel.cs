using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess_Layer.ViewModel
{
    public class DrugsCreateViewModel
    {
        public string DrugTitle { get; set; }
        public int DrugGroupID { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
