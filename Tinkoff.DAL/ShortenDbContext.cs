using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tinkoff.DAL.Models;

namespace Tinkoff.DAL
{
    public class ShortenDbContext : DbContext
    { 
        public DbSet<Shorten> Shortens { get; set; }
    }
}
