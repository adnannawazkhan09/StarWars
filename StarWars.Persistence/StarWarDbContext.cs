using Microsoft.EntityFrameworkCore;
using StarWars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Persistence
{
    public class StarWarDbContext : DbContext
    {
        public StarWarDbContext(
            DbContextOptions<StarWarDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarWarDbContext).Assembly);
        }

        public DbSet<StarShips> Ships { get; set; }

    }
}
