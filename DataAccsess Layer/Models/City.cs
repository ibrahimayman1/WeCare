using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    [Index(nameof(CityTittle))]
    public class City
    {
        public City()
        {
            CreationDate=DateTime.Now;
        }
       [Key]
        public int CityID { get; set; }

        [Required]
        [MaxLength(20)]
        public string CityTittle { get; set; }
        [MaxLength(20)]
        [Required]
        public DateTime CreationDate { get; set; }

      
    }
}
