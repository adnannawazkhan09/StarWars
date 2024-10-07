using StarWars.Core.Interface;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWars.Models.Response;
using System.Collections.Generic;
using StarWars.Persistence.Interfaces;
using StarWars.Core.Mapper;
using StarWars.Models.Request;

namespace StarWars.Core.Concrete
{
    public class StarShipService : IStarShipService
    {
        private readonly IStarShipRepository _starShipRepository;

        public StarShipService(IStarShipRepository starShipRepository)
        {
            _starShipRepository = starShipRepository;
        }

        public Task<bool> DeleteStarShip(int shipId)
        {
            return _starShipRepository.DeleteStarShip(shipId);
        }

        public async Task<IEnumerable<ShipResponseModel>> GetShipsAsync()
        {
            var response = await _starShipRepository.GetAllAsync();

            return response.ConvertToShipResponseModel();
        }

        public async Task<ShipResponseModel> GetShipsByIdAsync(int shipId)
        {
            var response = await _starShipRepository.GetShipAsync(shipId);

            if (response != null)
                return response.ConvertToShipResponseModel();

            return new ShipResponseModel();
        }

        public async Task<bool> InsertShipAsync(
                ShipRequestModel requestModel)
        {
            return await _starShipRepository.InsertStarShip(requestModel.ConvertToStarShip());
        }
    }
}
