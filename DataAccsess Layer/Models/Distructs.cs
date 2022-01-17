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
        [Key]
        public int DistrictID { get; set; }
        public String DistrictTitle { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
