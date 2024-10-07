using Newtonsoft.Json;
using StarWars.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Core.Concrete
{
    public class StarWarAPIService
    {
        private readonly HttpClient _httpClient;

        public StarWarAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<StarWarApiServiceResponseModel> GetProductsFromApi()
        {
            string apiUrl = "https://swapi.dev/api/starships";

            // Call the API and get the response
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the API response into a list of products
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StarWarApiServiceResponseModel>(content)!;
            }

            return new StarWarApiServiceResponseModel();
        }
    }

   
   

}
