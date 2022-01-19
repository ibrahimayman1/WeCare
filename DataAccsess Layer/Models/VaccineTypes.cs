using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    [Index(nameof(VaccineTypeTittle))]
    public class VaccineTypes
    {
        public VaccineTypes()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int VaccineTypeID { get; set; }
        [Required]
        [MaxLength(50)]
        public string VaccineTypeTittle { get; set; }
        [Required]
        public DateTime  CreationDate { get; set; }

    }
}
