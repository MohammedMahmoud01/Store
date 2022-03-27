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
    public interface IClsItem
    {
        List<ItemModel> GetAllItems();
        TbItem GetItem(int id);
        //List<TbCategory> GetCategories();
        List<TbSubCategory> GetSubCategories();
        bool Add(TbItem item);
        bool Edit(TbItem item);
        bool Delete(int itemId);
    }
    public class ClsItem : IClsItem
    {
        StoreContext ctx;
        public ClsItem(StoreContext service)
        {
            ctx = service;
        }

        //public List<TbCategory> GetCategories()
        //{
        //    return ctx.TbCategories.Include(x=>x.TbSubCategories).ToList();
        //}

        public List<TbSubCategory> GetSubCategories()
        {
            return ctx.TbSubCategories.ToList();
        }

        public TbItem GetItem(int id)
        {
            return ctx.TbItems.FirstOrDefault(x=>x.ItemId == id);
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

        public bool Add(TbItem item)
        {
            try
            {
                ctx.Add<TbItem>(item);

                //ctx.TbItems.Add(item);

                ctx.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
                
        }

        public bool Edit(TbItem item)
        {
            try
            {
                TbItem OldItem = ctx.TbItems.Where(a => a.ItemId == item.ItemId).FirstOrDefault();

                OldItem.ItemId = item.ItemId;
                OldItem.ItemName = item.ItemName;
                OldItem.SalesPrice = item.SalesPrice;
                OldItem.PurchasePrice = item.PurchasePrice;
                OldItem.SubCategoryId = item.SubCategoryId;
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
                TbItem OldItem = ctx.TbItems.Where(a => a.ItemId == itemId).FirstOrDefault();

                ctx.TbItems.Remove(OldItem);

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
