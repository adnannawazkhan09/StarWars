using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StarWars.Models.Response;
using System.Net.Http;

namespace StarWars.UI.Pages
{
    public class RandomShipsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;

        public ShipResponseModel Starships { get; set; }


        public RandomShipsModel(
            ILogger<IndexModel> logger,
            HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {

            Random random = new Random();
            int randomNumber = random.Next(1, 11);

            var apiUrl = $"https://localhost:7061/api/StarShip/getById?shipId={randomNumber}";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var starshipResponse = JsonConvert.DeserializeObject<ShipResponseModel>(response)!;

            Starships = starshipResponse;
        }
    }
}
