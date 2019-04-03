using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Views.Page
{
    public class Page
    {
        public int Number { get; private set; }
        public string Content { get; private set; }

        public Page(int number, string content)
        {
            Number = number;
            Content = content;
        }
    }
}
