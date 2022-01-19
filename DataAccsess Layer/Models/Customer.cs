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
    [Index(nameof(CustomerName))]
    public class Customer
    {
        public Customer()
        {
            CreationDate = DateTime.Now;
        }
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(20)]
        public string CustomerName { get; set; }
        [MaxLength(20)]
        [Required]
        public string CustomerNumber { get; set; }
        [MaxLength(20)]
       
        public string CustomerNumber2 { get; set; }
        [MaxLength(50)]
      
        public string CustomerEmail { get; set; }
        [MaxLength(20)]
        [Required]
        public DateTime CustomerBirthDay { get; set; }
        [MaxLength(15)]
        [Required]
        public string CustomerGender{ get; set; }
        [Required]
        [MaxLength(200)]
        public string CustomerAddress { get; set; }
       
        [MaxLength(200)]
        public string CustomerNote { get; set; }
    
        public int? ParentID { get; set; }
        public virtual Customer kids { get; set; }
        [Required]
        public int DistructID { get; set; }
        [ForeignKey("DistructID")]
        public Distructs Distructs { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [ForeignKey("ParentID")]
        public virtual Customer Parent { get; set; }
      



    }
}
