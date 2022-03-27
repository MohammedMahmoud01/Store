using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Bl
{
    public interface IClsHomePage
    {
        List<TbItem> GetAllItems();
        List<TbItem> GetPopularItems();
        List<TbItemDiscount> GetItemsDiscount();
        List<TbItem> GetRelatedItems(int id);
        TbItem GetById(int id);
        List<TbSlider> GetSliders();
        List<TbMobileLogo> GetMobileLogos();
    }
    public class ClsHomePage : IClsHomePage
    {
        StoreContext ctx;
        public ClsHomePage(StoreContext service)
        {
            ctx = service;
        }
        public List<TbItem> GetAllItems()
        {
            return ctx.TbItems.ToList();
        }

        public TbItem GetById(int id)
        {
            return ctx.TbItems.Include(x=>x.TbImages).Include(x=>x.SubCategory).FirstOrDefault(x=>x.ItemId == id);
        }

        public List<TbItemDiscount> GetItemsDiscount()
        {
            return ctx.TbItemDiscounts.Include(x=>x.Item).ToList();
        }

        public List<TbMobileLogo> GetMobileLogos()
        {
            return ctx.TbMobileLogo.ToList();
        }

        public List<TbItem> GetPopularItems()
        {
            return ctx.TbItems.Where(x=>x.SalesPrice > 3000 && x.SalesPrice < 9000).ToList();
        }

        public List<TbItem> GetRelatedItems(int id)
        {
            TbItem Item = GetById(id);

            decimal startPrice = Item.SalesPrice - 5000;

            decimal endPrice = Item.SalesPrice + 5000;

            return ctx.TbItems.Where(x => x.SalesPrice > startPrice && x.SalesPrice < endPrice).ToList();
        }

        public List<TbSlider> GetSliders()
        {
            return ctx.TbSlider.ToList();
        }
    }
}
