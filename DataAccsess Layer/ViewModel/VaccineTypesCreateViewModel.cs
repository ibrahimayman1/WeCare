﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess_Layer.ViewModel
{
    public class VaccineTypesCreateViewModel
    {
        public int VaccineTypeID { get; set; }
        public string VaccineTypeTittle { get; set; }
        public DateTime CreationDate { get; set; }
    }
}