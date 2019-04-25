using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.Models
{
    public class PagesContext : DbContext
    {
        public PagesContext(DbContextOptions<PagesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Page> Pages { get; set; }
    }
}
