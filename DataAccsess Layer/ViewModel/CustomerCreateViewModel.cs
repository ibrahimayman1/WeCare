using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess_Layer.ViewModel
{
    public class CustomerCreateViewModel
    {
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustomerNumber2 { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CustomerBirthDay { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerNote { get; set; }
        public int ParentID { get; set; }

        public int DistructID { get; set; }
    }
}
