using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Store.Models;
using Microsoft.EntityFrameworkCore;
using Store.Areas.Admin.Models;
using Domains;

namespace Store.Areas.Admin.Bl
{
    public interface IClsItemDiscount
    {
        List<ItemDiscountModel> GetAllDiscountItems();
        List<ItemModel> GetAllItems();
        TbItemDiscount GetItem(int id);
        bool Add(TbItemDiscount item);
        bool Edit(TbItemDiscount item);
        bool Delete(int itemId);
    }
    public class ClsItemDiscount : IClsItemDiscount
    {
        StoreContext ctx;
        public ClsItemDiscount(StoreContext service)
        {
            ctx = service;
        }

        public TbItemDiscount GetItem(int id)
        {
            return ctx.TbItemDiscounts.FirstOrDefault(x=>x.ItemDiscountId == id);
        }
        public List<ItemModel> GetAllItems()
        {
            var query = from item in ctx.TbItems
                        join cat1 in ctx.TbCategories
                        on item.CategoryId equals cat1.CategoryId
                        join cat2 in ctx.TbSubCategories
                        on item.SubCategoryId equals cat2.SubCategoryId
                        select new ItemModel
                        {
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            SalesPrice = item.SalesPrice,
                            ImageName = item.ImageName,
                            PurchasePrice = item.PurchasePrice,
                            CategoryName = cat1.CategoryName,
                            SubCategoryName = cat2.SubCategoryName
                        };
            return query.ToList();

        }
        public List<ItemDiscountModel> GetAllDiscountItems()
        {
            var query = from itemDiscount in ctx.TbItemDiscounts
                        join item in ctx.TbItems
                        on itemDiscount.ItemId equals item.ItemId
                        join cat2 in ctx.TbSubCategories
                        on item.SubCategoryId equals cat2.SubCategoryId
                        select new ItemDiscountModel
                        {
                            ItemDiscountId = itemDiscount.ItemDiscountId,
                            ItemName = item.ItemName,
                            SalesPrice = item.SalesPrice,
                            ImageName = item.ImageName,
                            DiscountPrice = itemDiscount.DiscountPrice,
                            SubCategoryName = cat2.SubCategoryName
                        };
            return query.ToList();

        }

        public bool Add(TbItemDiscount item)
        {
            try
            {
                ctx.Add<TbItemDiscount>(item);

                //ctx.TbItemDiscount.Add(item);

                ctx.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
                
        }

        public bool Edit(TbItemDiscount item)
        {
            try
            {
                TbItemDiscount OldItem = ctx.TbItemDiscounts.Where(a => a.ItemDiscountId == item.ItemId).FirstOrDefault();

                OldItem.ItemId = item.ItemId;
                OldItem.DiscountPrice = item.DiscountPrice;
                OldItem.SalesPrice = item.SalesPrice;
                OldItem.DiscountPercent = item.DiscountPercent;
                OldItem.EndDate = item.EndDate;
                OldItem.StartDate = item.StartDate;

                if(item.ImageName != null)
                    OldItem.ImageName = item.ImageName;

                ctx.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        public bool Delete(int itemId)
        {
            try
            {
                TbItemDiscount OldItem = ctx.TbItemDiscounts.Where(a => a.ItemDiscountId == itemId).FirstOrDefault();

                ctx.TbItemDiscounts.Remove(OldItem);

                ctx.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }
    }
}
