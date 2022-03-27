using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Areas.Admin.Bl;
using Store.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Domains;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        IClsSlider ctx;
        public SliderController(IClsSlider service)
        {
            ctx = service;
        }
        public IActionResult SliderDT()
        {
            return View(ctx.GetSliders());
        }
        public IActionResult Edit(int? Id)
        {
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
            return RedirectToAction("SliderDT");
        }

        [HttpPost]
        public async Task<IActionResult> Save(TbSlider slider, List<IFormFile> Files)
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
                        slider.SliderImage = ImageName;
                    }
                }

                if (slider.SliderId == 0)
                    ctx.Add(slider);
                else
                    ctx.Edit(slider);
                return RedirectToAction("SliderDT");
            }
            else
                return RedirectToAction("Edit");
        }
    }
}
