using Store.Areas.Admin.Bl;
using Store.Areas.Admin.Models;
using Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domains;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ItemImageController : Controller
    {
        IClsItemImage ctx;
        IClsItem ctx2;
        public ItemImageController(IClsItemImage service , IClsItem service2)
        {
            ctx = service;
            ctx2 = service2;
        }
        public IActionResult ItemImageDT()
        {
            List<ItemImageModel> lstItemImages = ctx.GetAllImages();
            return View(lstItemImages);
        }
        public IActionResult Edit(int? Id)
        {
            ViewBag.ItemsNames = ctx2.GetAllItems();

            if (Id == null)
                return View();
            else
            {
                return View(ctx.GetById(Convert.ToInt32(Id)));
            }
        }
        public IActionResult Delete(int Id)
        {
            ctx.Delete(Id);
            return RedirectToAction("ItemImageDT");
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbImage image, List<IFormFile> Files)
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
                        image.ImageName = ImageName;
                    }
                }

                if (image.ImageId == 0)
                    ctx.Add(image);
                else
                    ctx.Edit(image);
                return RedirectToAction("ItemImageDT");
            }
            else
                return RedirectToAction("Edit");
        }
    }
}
