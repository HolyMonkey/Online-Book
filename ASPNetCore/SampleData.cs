using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCore.Models;

namespace ASPNetCore
{
    public static class SampleData
    {
        public static void Initialize(PagesContext context)
        {
            if (!context.Pages.Any())
            {
                context.Pages.AddRange(
                    new Page(1, "First page"),
                    new Page(2, "Second page"),
                    new Page(3, "Thred page")
                );
                context.SaveChanges();
            }
        }
    }
}
