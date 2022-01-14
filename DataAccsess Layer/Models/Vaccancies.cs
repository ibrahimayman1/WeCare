using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class Vaccancies
    {
        [Key]
        public int VaccineID { get; set; }
        [Required]
        public string VaccineTittle { get; set; }

        public int VaccineMonths { get; set; }
        public int VaccineTypeID { get; set; }
        [ForeignKey("VaccineTypeID")]
        public VaccineTypes VaccineTypes { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
