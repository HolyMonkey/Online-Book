using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNetCore.Models;

namespace ASPNetCore.Controllers
{
    public class PageController : Controller
    {
        private readonly PagesContext _context;

        public PageController(PagesContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        [Route("[action]/{page:int}")]
        public IActionResult Page(int page)
        {
            Page _page = _context.Pages.FirstOrDefault(p => p.Number == page);
            Page _previouspage = _context.Pages.FirstOrDefault(p => p.Number == page -1);
            Page _nextpage = _context.Pages.FirstOrDefault(p => p.Number == page + 1);
            
            ViewData["PreviousPage"] = _previouspage;
            ViewData["NextPage"] = _nextpage;

            if (_page != null)
            {
                ViewData["Page"] = _page.Number;
                ViewData["PageName"] = _page.Name;
                ViewData["PageContent"] = _page.Content;
            }
            else
            {
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string pagename, string pagecontent)
        {
            int pagenumber = (_context.Pages.Count())+1;
            _context.Pages.Add(new Page(pagenumber, pagename, pagecontent));
            _context.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult Contents()
        {
            Chapter FirstChapter = new Chapter("First chapter", new List<Page> { new Page(1, "First page", "First page content") });
            Chapter SecondChapter = new Chapter("Second chapter", new List<Page> { new Page(2, "Second page", "Second page content"), new Page(3, "Thred page", "Thred page content") });
            List<Chapter> contents = new List<Chapter>();
            contents.Add(FirstChapter);
            contents.Add(SecondChapter);

            return View(contents);
        }
    }
}