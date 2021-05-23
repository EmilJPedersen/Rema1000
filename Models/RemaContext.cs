using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rema1000.Models;

namespace Rema1000.Models
{
    public class RemaContext : DbContext
    {
        public RemaContext(DbContextOptions<RemaContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Produkt> Produkt { get; set; }

        public virtual DbSet<Kategori> Kategori { get; set; }

        public virtual DbSet<Leverandør> Leverandør { get; set; }
    }
}
