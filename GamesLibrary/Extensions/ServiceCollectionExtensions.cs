using GamesLibrary.GameLibraryService.Abstractions;
using GamesLibrary.Infrastructure.Db.Repositories;
using GamesLibrary.Infrastructure.Db.Repositories.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamesLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
    => services.AddScoped<IGameLibraryService, GamesLibrary.GameLibraryService.GameLibraryService>();

        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
      services.AddScoped<IGameRepo, GameRepo>();
              
    }
}
