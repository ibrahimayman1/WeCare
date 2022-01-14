﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class DrugsGroups
    {
        [Key]
        public int DrugsGroupID { get; set; }
        [Required]
        public string  GroupTittle { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
