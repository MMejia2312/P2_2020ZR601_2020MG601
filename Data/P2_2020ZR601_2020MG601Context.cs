using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P2_2020ZR601_2020MG601.Models;

namespace P2_2020ZR601_2020MG601.Data
{
    public class P2_2020ZR601_2020MG601Context : DbContext
    {
        public P2_2020ZR601_2020MG601Context (DbContextOptions<P2_2020ZR601_2020MG601Context> options)
            : base(options)
        {
        }

        public DbSet<P2_2020ZR601_2020MG601.Models.departamento> departamento { get; set; } = default!;

        public DbSet<P2_2020ZR601_2020MG601.Models.genero>? genero { get; set; }
    }
}
