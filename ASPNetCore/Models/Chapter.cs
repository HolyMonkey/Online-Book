using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Models
{
    public class Chapter
    {
        public string Name { get; private set; }
        public List<Page> Pages { get; private set; }

        public Chapter(string name, List<Page> pages)
        {
            Name = name;
            Pages = pages;
        }
    }
}
