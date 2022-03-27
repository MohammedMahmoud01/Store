using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Bl;
using Store.Models;
using X.PagedList;
using Domains;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    public class Items : Controller
    {
        IClsItemsCat ctx;
        public Items(IClsItemsCat service)
        {
            ctx = service;
        }
        public IActionResult AllItems(int? page)
        {
            var pageNumber = page ?? 1; // if no page is specified, default to the first page (1)

            int pageSize = 12; // Get 25 students for each requested page.

            var onePageOfStudents = ctx.GetAllProducts().ToPagedList(pageNumber, pageSize);

            return View(onePageOfStudents); // Send 25 students to the page.

        }
        public IActionResult Samsung(int? page)
        {
            var pageNumber = page ?? 1; 

            int pageSize = 12;

            var onePageOfStudents = ctx.GetSamsung().ToPagedList(pageNumber, pageSize);

            return View(onePageOfStudents);
        }
        public IActionResult xiaomi(int? page)
        {
            var pageNumber = page ?? 1;

            int pageSize = 12;

            var onePageOfStudents = ctx.GetXiaomi().ToPagedList(pageNumber, pageSize);

            return View(onePageOfStudents);
        }
        public IActionResult Apple(int? page)
        {
            var pageNumber = page ?? 1;

            int pageSize = 12;

            var onePageOfStudents = ctx.GetApple().ToPagedList(pageNumber, pageSize);

            return View(onePageOfStudents);
        }
        public IActionResult ItemsList()
        {
            HomePageModel model = new HomePageModel();

            model.lstItems = ctx.GetAllProducts().Skip(30).Take(3).ToList();

            model.lstNewItems = ctx.GetAllProducts().Skip(33).Take(3).ToList();

            return View(model);
        }
    }
}
