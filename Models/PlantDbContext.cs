using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantMicroservice.Models
{
    public class PlantDbContext:DbContext
    {
        public PlantDbContext(DbContextOptions<PlantDbContext> options) : base(options) { }

        public DbSet<Part> Parts { get; set; }
        public DbSet<ReorderRules> ReoRule { get; set; }
        public DbSet<PlantReorderDetails> PlantReoDetail { get; set; }
        public DbSet<Demand> Demands { get; set; }
    }
}
