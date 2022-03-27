using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ShoopingCartModel
    {
        public ShoopingCartModel()
        {
            lstItems = new List<ShoopingCartItem>();
        }
        public List<ShoopingCartItem> lstItems { get; set; }
        public decimal Total { get; set; }
    }
}
