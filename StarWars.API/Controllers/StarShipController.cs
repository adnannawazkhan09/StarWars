using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarWars.Core.Interface;
using StarWars.Models.Request;

namespace StarWars.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarShipController : ControllerBase
    {
        private readonly IStarShipService _starShipService;

        public StarShipController(IStarShipService starShipService)
        {
            _starShipService = starShipService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _starShipService.GetShipsAsync();
            return Ok(response); 
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> Get(int shipId)
        {
            var response = await _starShipService.GetShipsByIdAsync(shipId);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShipRequestModel shipRequestModel)
        {
            var response = await _starShipService.InsertShipAsync(shipRequestModel);
            return Ok(response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete (int shipId)
        {
            var response = await _starShipService.DeleteStarShip(shipId);
            return Ok(response);
        }
    }
}
