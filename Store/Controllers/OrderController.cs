using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;
using Domains;
using Store.Bl;

namespace Store.Controllers
{
    public class OrderController : Controller
    {
        IClsHomePage ctx;
        public OrderController(IClsHomePage service)
        {
            ctx = service;
        }
        public IActionResult Cart()
        {
            ShoopingCartModel oShopingCart = HttpContext.Session.GetObjectFromJson<ShoopingCartModel>("Cart");
            if (oShopingCart == null)
                return Redirect("/Users/AccessDenied");
            else
                return View(oShopingCart);
        }

        public IActionResult RemoveItem(int Id)
        {
            ShoopingCartModel oShopingCart = HttpContext.Session.GetObjectFromJson<ShoopingCartModel>("Cart");

            oShopingCart.lstItems.Remove(oShopingCart.lstItems.Where(a => a.ItemId == Id).FirstOrDefault());

            oShopingCart.Total = oShopingCart.lstItems.Sum(a => a.Total);

            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);

            return RedirectToAction("Cart");
        }
        public IActionResult AddToCart(int Id)
        {
            ShoopingCartModel oShopingCart = HttpContext.Session.GetObjectFromJson<ShoopingCartModel>("Cart");
            if (oShopingCart == null)
                oShopingCart = new ShoopingCartModel();

            TbItem item = ctx.GetById(Id);
            ShoopingCartItem shopingItem = oShopingCart.lstItems.FirstOrDefault(a => a.ItemId == Id);
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oShopingCart.lstItems.Add(new ShoopingCartItem()
                {
                    ItemId = item.ItemId,
                    ItemName = item.ItemName,
                    ImageName = item.ImageName,
                    Price = item.SalesPrice,
                    Qty = 1,
                    Total = item.SalesPrice
                });
            }

            oShopingCart.Total = oShopingCart.lstItems.Sum(a => a.Total);

            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);

            return Redirect("/Home/Index");
        }
    }
}
