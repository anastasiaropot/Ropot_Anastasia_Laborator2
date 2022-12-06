using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ropot_Anastasia_Lab2.Models;

namespace Ropot_Anastasia_Lab2.Data
{
    public class Ropot_Anastasia_Lab2Context : DbContext
    {
        public Ropot_Anastasia_Lab2Context (DbContextOptions<Ropot_Anastasia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Ropot_Anastasia_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Ropot_Anastasia_Lab2.Models.Publisher> Publisher { get; set; }
    }
}
