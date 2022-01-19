using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess_Layer.ViewModel.GeneralResponse
{
    public class GeneralResponse<T>
    {
        public GeneralResponse() { Data = new List<T>(); }

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<T> Data { get; set; }
        public Boolean Success { get; set; }

    }
}
