using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class City
    {
       [Key]
        public int CityID { get; set; }

        
        public string CityTittle { get; set; }
        public DateTime CreationDate { get; set; }
        
    }
}
