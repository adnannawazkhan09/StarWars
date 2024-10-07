
using StarWars.Core.Concrete;
using StarWars.Core.Interface;
using StarWars.Persistence.Concrete;
using StarWars.Persistence.Interfaces;

namespace StarWars.API.Extensions
{
    public static class DepedencyRegistration
    {

        public static IServiceCollection RegisterDbDepedencies(
            this  IServiceCollection services)
        {
            services.AddTransient<IStarShipRepository, StarShipRepository>();
            return services;
        }

        public static IServiceCollection RegisterServices(
            this IServiceCollection services)
        {
            services.AddTransient<IStarShipService, StarShipService>();
            return services;
        }
    }
}
