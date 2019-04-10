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
            _context.Add(new Page(1, "First page"));
            _context.Add(new Page(2, "Second page"));
            _context.Add(new Page(3, "Third page"));
            _context.SaveChanges();
            Page _page = _context.Pages.FirstOrDefault(p => p.Number == page);
            Page _previouspage = _context.Pages.FirstOrDefault(p => p.Number == page -1);
            Page _nextpage = _context.Pages.FirstOrDefault(p => p.Number == page + 1);
            
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

        public IActionResult Contents()
        {
            Chapter FirstChapter = new Chapter("First chapter", new List<Page> { new Page(1, "First page") });
            Chapter SecondChapter = new Chapter("Second chapter", new List<Page> { new Page(2, "Second  page"), new Page(3, "Third page") });
            List<Chapter> contents = new List<Chapter>();
            contents.Add(FirstChapter);
            contents.Add(SecondChapter);

            return View(contents);
        }
    }
}