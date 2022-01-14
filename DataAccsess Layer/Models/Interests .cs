using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class Interests
    {
        [Key]
        public int InterestsID { get; set; }
        public string InterestsTittle { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
