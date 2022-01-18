using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motim_Data_Access_Layer.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerNumber2 { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerBirthDay { get; set; }
        public string CustomerGender{ get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNote { get; set; }
        public int? ParentID { get; set; }
       
        public int DistructID { get; set; }
        [ForeignKey("DistructID")]
        public Distructs Distructs { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("ParentID")]
        public Customer parent { get; set; }


    }
}
