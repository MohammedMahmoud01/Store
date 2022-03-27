using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Areas.Admin.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ImageName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }

    }
}
