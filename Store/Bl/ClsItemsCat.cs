using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Store.Models;

namespace Store.Bl
{
    public interface IClsItemsCat
    {
        List<TbItem> GetSamsung();
        List<TbItem> GetXiaomi();
        List<TbItem> GetApple();
        List<TbItem> GetAllProducts();
        List<ItemsApiModel> GetAllItems();
        List<CategoryModel> GetAllCategories();
    }
    public class ClsItemsCat : IClsItemsCat
    {
        StoreContext ctx;
        public ClsItemsCat(StoreContext service)
        {
            ctx = service;
        }

        public List<CategoryModel> GetAllCategories()
        {
            var query = from cat in ctx.TbCategories
                        join subCat in ctx.TbSubCategories
                        on cat.CategoryId equals subCat.CategoryId
                        select new CategoryModel
                        {
                            CategoryId = cat.CategoryId,
                            CategoryName = cat.CategoryName,
                            SubCategoryId = subCat.SubCategoryId,
                            SubCategoryName = subCat.SubCategoryName
                        };

            return query.ToList();
        }

        public List<ItemsApiModel> GetAllItems()
        {
            var query = from item in ctx.TbItems
                        join cat in ctx.TbCategories
                        on item.CategoryId equals cat.CategoryId
                        join subCat in ctx.TbSubCategories
                        on item.SubCategoryId equals subCat.SubCategoryId
                        select new ItemsApiModel
                        {
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            SalesPrice = item.SalesPrice,
                            ImageName = item.ImageName,
                            CategoryName = cat.CategoryName,
                            SubCategoryId = item.SubCategoryId,
                            SubCategoryName = subCat.SubCategoryName
                        };

            return query.ToList();
        }

        public List<TbItem> GetAllProducts()
        {
            return ctx.TbItems.ToList();
        }

        public List<TbItem> GetApple()
        {
            return ctx.TbItems.Where(x => x.SubCategoryId == 2).ToList();
        }

        public List<TbItem> GetSamsung()
        {
            return ctx.TbItems.Where(x => x.SubCategoryId == 1).ToList();
        }

        public List<TbItem> GetXiaomi()
        {
            return ctx.TbItems.Where(x => x.SubCategoryId == 3).ToList();
        }
    }
}
