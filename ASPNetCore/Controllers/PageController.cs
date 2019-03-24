using System;
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

        [Route("{action = Page}/{page:int}")]
        public IActionResult Page(int page)
        {
            List<Page> pages = new List<Page>();
            pages.Add(new Page(1, "First page"));
            pages.Add(new Page(2, "Second page"));
            Page _page = pages.Find((p) => p.Number == page);
            if (_page != null)
            {
                ViewData["Page"] = _page.Number;
                ViewData["Message"] = _page.Content;
            }
            return View();
        }
    }
}