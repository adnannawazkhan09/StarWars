using Microsoft.EntityFrameworkCore;
using StarWars.Domain;
using StarWars.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Persistence.Concrete
{
    public class StarShipRepository : IStarShipRepository
    {
        private readonly StarWarDbContext _context;

        public StarShipRepository(StarWarDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteStarShip(int shipId)
        {
            var shipDetails = _context.Ships.Find(shipId);
            if (shipDetails != null)
            {
                _context.Ships.Remove(shipDetails);
                int recordsDeleted = await _context.SaveChangesAsync();
                return recordsDeleted > 0;
            }
            return false;
        }

        public async Task<IQueryable<StarShips>> GetAllAsync()
        {
            return await Task.FromResult(_context.Ships);
        }

        public async Task<StarShips> GetShipAsync(int shipId)
        {
            return await _context.Ships.FindAsync(shipId)!;
        }

        public async Task<bool> InsertStarShip(StarShips starShips)
        {

            var existingRecords = await _context.Ships.FindAsync(starShips.Id);

            if (existingRecords == null)
            {
                _context.Ships.Add(starShips);
                _context.Entry(starShips).State = EntityState.Added;
            }
            else
            {
                existingRecords.Manufacturer = starShips.Manufacturer;
                existingRecords.Length = starShips.Length;
                existingRecords.Films = starShips.Films;
                existingRecords.Url = starShips.Url;
                existingRecords.Pilots = starShips.Pilots;
                existingRecords.Passengers = starShips.Passengers;
                // add more feilds

                _context.Ships.Add(existingRecords);
                _context.Entry(existingRecords).State = EntityState.Modified;
            }

            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
