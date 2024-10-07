using StarWars.Models.Request;
using StarWars.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Interface
{
    public interface IStarShipService
    {
        Task<IEnumerable<ShipResponseModel>> GetShipsAsync();

        Task<ShipResponseModel> GetShipsByIdAsync(int shipId);

        Task<bool> InsertShipAsync(ShipRequestModel requestModel);

        Task<bool> DeleteStarShip(int shipId);
    }
}
