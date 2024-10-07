using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models.Request
{
    public class ShipRequestModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } = default!;
        public string Model { get; set; } = default!;
        public string Manufacturer { get; set; } = default!;
        public string CostInCredits { get; set; } = default!;
        public string Length { get; set; } = default!;
        public string MaxAtmospheringSpeed { get; set; } = default!;
        public string Crew { get; set; } = default!;
        public string Passengers { get; set; } = default!;
        public string CargoCapacity { get; set; } = default!;
        public string Consumables { get; set; } = default!;
        public string HyperdriveRating { get; set; } = default!;
        public string MGLT { get; set; } = default!;
        public string StarshipClass { get; set; } = default!;
        public List<string> Pilots { get; set; } = new();
        public List<string> Films { get; set; } = new();
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public string Url { get; set; } = default!;
    }
}
