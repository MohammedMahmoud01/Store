using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSalesInvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public decimal SalesPrice { get; set; }
        public int Quantitiy { get; set; }
        public string Notes { get; set; }

        public virtual TbSalesInvoice Invoice { get; set; }
        public virtual TbItem Item { get; set; }
    }
}
