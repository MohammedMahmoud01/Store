﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbSalesInvoice
    {
        public TbSalesInvoice()
        {
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public int CustomerId { get; set; }
        public int DeliveryManId { get; set; }
        public string Notes { get; set; }

        public virtual TbCustomer Customer { get; set; }
        public virtual TbDeliveryMan DeliveryMan { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
    }
}
