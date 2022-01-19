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
        public Interests()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int InterestsID { get; set; }
        [Required]
        public string InterestsTittle { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

    }
}
