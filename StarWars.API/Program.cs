using StarWars.Domain;
using StarWars.API.Extensions;
using Microsoft.EntityFrameworkCore;
using StarWars.Persistence;
using StarWars.Repository.Concrete;
using StarWars.Core.Concrete;


namespace StarWars.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            string connectionString = builder.Configuration.GetConnectionString("StarWarDbContext")!;
            builder.Services.AddDbContext<StarWarDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });




            builder.Services
                .RegisterServices()
                .RegisterDbDepedencies();

            // Add HttpClient for API service
            builder.Services.AddHttpClient<StarWarAPIService>();
            // Register data seeder service
            builder.Services.AddScoped<DataSeederService>();
      

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var starWarAPIService = scope.ServiceProvider.GetRequiredService<StarWarAPIService>();
                var response = starWarAPIService.GetProductsFromApi().Result; // Call the seeding function

                if (response != null)
                {
                    var seed = response.results.Select(
                        x => new StarShips()
                        {
                            CargoCapacity = x.cargo_capacity,
                            Consumables = x.consumables,
                            CostInCredits = x.cost_in_credits,
                            CreatedOn = x.created,
                            Crew = x.crew,
                            EditedOn = x.edited,
                            Films = x.films,
                            HyperdriveRating = x.hyperdrive_rating,
                            Length = x.length,
                            Manufacturer = x.manufacturer,
                            MGLT = x.MGLT,
                            MaxAtmospheringSpeed = x.max_atmosphering_speed,
                            Model = x.model,
                            Name = x.name, 
                            Passengers = x.passengers,
                            Pilots = x.pilots,
                            StarshipClass = x.starship_class,
                            Url= x.url
                        }).ToList();

                    var seeder = scope.ServiceProvider.GetRequiredService<DataSeederService>();
                     seeder.SeedApiData(seed); // Call the seeding function
                }



            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
