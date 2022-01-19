using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    [Index(nameof(GroupTittle))]
    public class DrugsGroups
    {
        public DrugsGroups()
        {
            CreationTime = DateTime.Now;
        }
        [Key]
        public int DrugsGroupID { get; set; }
        [Required]
        [MaxLength(50)]
        public string  GroupTittle { get; set; }
        [Required]
        [MaxLength(20)]
        public DateTime CreationTime { get; set; }
    }
}
