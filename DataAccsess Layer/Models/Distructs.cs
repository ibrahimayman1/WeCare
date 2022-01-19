using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class Distructs
    {
        public Distructs()
        {
            CreationDate = DateTime.Now;
        }
        [Key]

        public int DistrictID { get; set; }
        [Required]
        public String DistrictTitle { get; set; }
        [Required]
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
