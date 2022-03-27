using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Store.Bl;
using Store.Models;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        IClsHomePage ctx;
        public HomeController(IClsHomePage service)
        {
            ctx = service;
        }
        public IActionResult Index()
        {
            HomePageModel model = new HomePageModel();

            model.lstItems = ctx.GetAllItems();

            model.lstNewItems = model.lstItems.Skip(8).Take(12);

            model.lstPopularItems = ctx.GetPopularItems();

            model.lstItemsDiscount = ctx.GetItemsDiscount();

            model.lstSliders = ctx.GetSliders();

            model.lstMobileLogos = ctx.GetMobileLogos();

            return View(model);
        }

        public IActionResult ItemDetails(int Id)
        {
            ItemDetailsModel model = new ItemDetailsModel();

            model.Item = ctx.GetById(Id);

            model.lstRelatedItems = ctx.GetRelatedItems(Id);

            return View(model);
        }
    }
}
