using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using StarWars.Models.Response;
using System.Net.Http;

namespace StarWars.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;

        public List<ShipResponseModel> Starships { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGet()
        {
            var apiUrl = "https://localhost:7061/api/StarShip";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var starshipResponse = JsonConvert.DeserializeObject<List<ShipResponseModel>>(response)!;

            Starships = starshipResponse;
        }
    }
}
