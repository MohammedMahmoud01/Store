using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Areas.Admin.Bl;
using Store.Models;
using Microsoft.AspNetCore.Authorization;
using Domains;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : Controller
    {
        IClsSubCategory ctx;
        public SubCategoryController(IClsSubCategory service)
        {
            ctx = service; 
        }
        public IActionResult SubCategoryDT()
        {
            return View(ctx.GetSubCategories());
        }
        public IActionResult Edit(int? Id)
        {
            ViewBag.Categories = ctx.GetCategories();

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
            return RedirectToAction("SubCategoryDT");
        }
        [HttpPost]
        public async Task<IActionResult> Save(TbSubCategory cat)
        {
            if (ModelState.IsValid)
            {
                //foreach (var file in Files)
                //{
                //    if (file.Length > 0)
                //    {
                //        string ImageName = Guid.NewGuid().ToString() + ".jpg";
                //        var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                //        using (var stream = System.IO.File.Create(filePaths))
                //        {
                //            await file.CopyToAsync(stream);
                //        }
                //        item.ImageName = ImageName;
                //    }
                //}

                if (cat.SubCategoryId == 0)
                    ctx.Add(cat);
                else
                    ctx.Edit(cat);
                return RedirectToAction("SubCategoryDT");
            }
            else
                return RedirectToAction("Edit");
        }
    }
}
