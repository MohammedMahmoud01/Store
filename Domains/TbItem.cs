using System;
using System.Collections.Generic;

#nullable disable

namespace Domains
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbImages = new HashSet<TbImage>();
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
            TbItemDiscounts = new HashSet<TbItemDiscount>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationBy { get; set; }
        public DateTime UpdationDate { get; set; }
        public string UpdationBy { get; set; }
        public string Notes { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual TbSubCategory SubCategory { get; set; }
        public virtual ICollection<TbImage> TbImages { get; set; }
        public virtual ICollection<TbItemDiscount> TbItemDiscounts { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
    }
}
