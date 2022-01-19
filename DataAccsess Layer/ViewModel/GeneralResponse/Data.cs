using System.Collections.Generic;

namespace DataAccsess_Layer.ViewModel.GeneralResponse
{
    public class Data<T>
    { 
        public List<T> Objects { get; set; }     
    }
}
