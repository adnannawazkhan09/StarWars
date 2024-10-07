using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using StarWars.Domain;
using StarWars.Models.Request;
using StarWars.Models.Response;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Mapper
{
    public static class StarShipMapper
    {
        public static IEnumerable<ShipResponseModel> ConvertToShipResponseModel(
            this IEnumerable<StarShips> starShips)
        {
            return starShips.Select(x => x.ConvertToShipResponseModel());
        }

        public static ShipResponseModel ConvertToShipResponseModel(
           this StarShips starShips)
        {
            return new ShipResponseModel()
            {
                CargoCapacity = starShips.CargoCapacity,
                Consumables = starShips.Consumables,
                CostInCredits = starShips.CostInCredits,
                CreatedOn = starShips.CreatedOn,
                Crew = starShips.Crew,
                EditedOn = starShips.EditedOn,
                Films = starShips.Films,
                HyperdriveRating = starShips.HyperdriveRating,
                Length = starShips.Length,
                Manufacturer = starShips.Manufacturer,
                MaxAtmospheringSpeed = starShips.MaxAtmospheringSpeed,
                MGLT = starShips.MGLT,
                Model = starShips.Model,
                Name = starShips.Name,
                Passengers = starShips.Passengers,
                Pilots = starShips.Pilots,
                StarshipClass = starShips.StarshipClass,
                Url = starShips.Url,
                Id = starShips.Id
            };
        }

        public static StarShips ConvertToStarShip(
            this ShipRequestModel shipRequestModel)
        {
            return new StarShips()
            {
                Id  = shipRequestModel.Id,
                CargoCapacity = shipRequestModel.CargoCapacity,
                Consumables = shipRequestModel.Consumables,
                CostInCredits = shipRequestModel.CostInCredits,
                CreatedOn = shipRequestModel.CreatedOn,
                Crew = shipRequestModel.Crew,
                EditedOn = shipRequestModel.EditedOn,
                Films = shipRequestModel.Films,
                HyperdriveRating = shipRequestModel.HyperdriveRating,
                Length = shipRequestModel.Length,
                Manufacturer = shipRequestModel.Manufacturer,
                MaxAtmospheringSpeed = shipRequestModel.MaxAtmospheringSpeed,
                MGLT = shipRequestModel.MGLT,
                Model = shipRequestModel.Model,
                Name = shipRequestModel.Name,
                Passengers = shipRequestModel.Passengers,
                Pilots = shipRequestModel.Pilots,
                StarshipClass = shipRequestModel.StarshipClass,
                Url = shipRequestModel.Url
            };
        }

    }
}
