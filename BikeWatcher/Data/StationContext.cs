using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BikeWatcher.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeWatcher.Data
{
    public class StationContext : DbContext
    {
        public StationContext(DbContextOptions<StationContext> options)
            : base(options)
        {
        }

        public DbSet<Stations> Stations { get; set; }
    }
}