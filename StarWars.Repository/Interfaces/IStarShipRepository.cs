using Microsoft.CodeAnalysis.CSharp.Syntax;
using StarWars.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Persistence.Interfaces
{
    public interface IStarShipRepository
    {
        Task<StarShips> GetShipAsync(int shipId);

        Task<IQueryable<StarShips>> GetAllAsync();

        Task<bool> InsertStarShip(StarShips starShips);

        Task<bool> DeleteStarShip(int shipId);
    }
}
