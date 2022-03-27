using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Models;
using Store.Areas.Admin.Bl;

using System.Dynamic;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Store.Areas.Admin.Models;
using Domains;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ItemController : Controller
    {
        IClsItem ctx;
        public ItemController(IClsItem service)
        {
            ctx = service;
        }
        public IActionResult ItemDT()
        {
            List<ItemModel> lstModel = ctx.GetAllItems();
            return View(lstModel);
        }

        public IActionResult Edit(int? Id)
        {
            ViewBag.Categories = ctx.GetSubCategories();

            //ViewData["ItemsCount"] = ctx.GetSubCategories();

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
            return RedirectToAction("ItemDT");    
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbItem item , List<IFormFile> Files)
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
                        item.ImageName = ImageName;
                    }
                }

                if (item.ItemId == 0)
                    ctx.Add(item);
                else
                    ctx.Edit(item);
                return RedirectToAction("ItemDT");
            }
            else
                return RedirectToAction("Edit");
        }
    }
}
