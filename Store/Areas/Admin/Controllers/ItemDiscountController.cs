using Store.Areas.Admin.Bl;
using Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Store.Areas.Admin.Models;
using Domains;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ItemDiscountController : Controller
    {
        IClsItemDiscount ctx;
        public ItemDiscountController(IClsItemDiscount service)
        {
            ctx = service;
        }
        public IActionResult ItemDiscountDT()
        {
            List<ItemDiscountModel> lstModel = ctx.GetAllDiscountItems();
            return View(lstModel);
        }

        public IActionResult Edit(int? Id)
        {
            ViewBag.ItemsName = ctx.GetAllItems();


            if (Id == null)
                return View();
            else
            {
                return View(ctx.GetItem(Convert.ToInt32(Id)));
            }
        }

        public IActionResult Delete(int Id)
        {
            ctx.Delete(Id);
            return RedirectToAction("ItemDiscountDT");
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbItemDiscount myItemDiscount, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                        using (var stream = System.IO.File.Create(filePaths))
                        {
                            await file.CopyToAsync(stream);
                        }
                        myItemDiscount.ImageName = ImageName;
                    }
                }

                if (myItemDiscount.ItemDiscountId == 0)
                    ctx.Add(myItemDiscount);
                else
                    ctx.Edit(myItemDiscount);
                return RedirectToAction("ItemDiscountDT");
            }
            else
                return RedirectToAction("Edit");
        }
    }
}
