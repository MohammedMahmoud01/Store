using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbItemDiscount
    {
        public int ItemDiscountId { get; set; }
        public int ItemId { get; set; }
        public string ImageName { get; set; }
        public decimal SalesPrice { get; set; }
        public double DiscountPercent { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual TbItem Item { get; set; }
    }
}
