using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    [Index(nameof(VaccineTittle))]
    public class Vaccancies
    {
        public Vaccancies()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int VaccineID { get; set; }
        [Required]
        [MaxLength(50)]
        public string VaccineTittle { get; set; }
        [Required]
       
        public int VaccineMonths { get; set; }
        [Required]
        public int VaccineTypeID { get; set; }
        [ForeignKey("VaccineTypeID")]
        public VaccineTypes VaccineTypes { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
