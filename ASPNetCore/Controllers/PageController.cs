﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNetCore.Views.Page;

namespace ASPNetCore.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        [Route("[action]/{page:int}")]
        public IActionResult Page(int page)
        {
            List<Page> pages = new List<Page>();
            pages.Add(new Page(1, "First page"));
            pages.Add(new Page(2, "Second page"));
            pages.Add(new Page(3, "Three page"));
            Page _page = pages.Find((p) => p.Number == page);
            Page _previouspage = pages.Find((p) => p.Number == page-1);
            Page _nextpage = pages.Find((p) => p.Number == page + 1);

            ViewData["PreviousPage"] = _previouspage;
            ViewData["NextPage"] = _nextpage;

            if (_page != null)
            {
                ViewData["Page"] = _page.Number;
                ViewData["Message"] = _page.Content;
            }
            else
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
    }
}