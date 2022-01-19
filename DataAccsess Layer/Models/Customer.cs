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
        public Customer()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerNumber { get; set; }
        [Required]
        public string CustomerNumber2 { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public DateTime CustomerBirthDay { get; set; }
        [Required]
        public string CustomerGender{ get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerNote { get; set; }
        [Required]
        public int? ParentID { get; set; }
        [Required]
        public int DistructID { get; set; }
        [ForeignKey("DistructID")]
        public Distructs Distructs { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }

       


    }
}
