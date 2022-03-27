using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbDeliveryMan
    {
        public TbDeliveryMan()
        {
            TbSalesInvoices = new HashSet<TbSalesInvoice>();
        }

        public int DeliveryManId { get; set; }
        public string DeliveryManName { get; set; }

        public virtual ICollection<TbSalesInvoice> TbSalesInvoices { get; set; }
    }
}
