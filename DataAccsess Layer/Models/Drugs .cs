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
    [Index(nameof(DrugTitle))]
    public class Drugs
    {

        public Drugs()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int DrugID { get; set; }
        [Required]
        [MaxLength(20)]
        public string DrugTitle { get; set; }
        [Required]
        public  int  DrugGroupID { get; set; }
        [ForeignKey("DrugGroupID")]
        public DrugsGroups DrugsGroups { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
