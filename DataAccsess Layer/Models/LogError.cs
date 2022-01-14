using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    internal class LogError
    {
        public LogError()
        {
            CreationDate=DateTime.Now;  
        }
        [Key]
        public int id { get; set; }
        public string errormessage { get; set; }
        public string ErrorStacks { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
