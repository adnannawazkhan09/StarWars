using StarWars.Domain;
using StarWars.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Repository.Concrete
{
    public class DataSeederService
    {
        private readonly StarWarDbContext _context;
        public DataSeederService(StarWarDbContext context)
        {
            _context = context;
        }

        public bool SeedApiData(List<StarShips> starShips)
        {
            if (_context.Ships.Count() == 0)
            {
                // Add the products to the EF Core context and save them
                _context.Ships.AddRange(starShips);
                int rowsAffected = _context.SaveChanges();
                return rowsAffected > 0;
            }
            return false;
          
        }
    }
}
