using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    [Index(nameof(InterestsTittle))]
    public class Interests
    {
        public Interests()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int InterestsID { get; set; }
        [Required]
        [MaxLength(50)]
        public string InterestsTittle { get; set; }
        [Required]
        [MaxLength(20)]
        public DateTime CreationDate { get; set; }

    }
}
