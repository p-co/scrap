using Microsoft.Extensions.DependencyInjection;
using Scrap.Repositories.Abstractions;

namespace Scrap.Repositories.Extensions.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IWebsiteRepository, WebsiteRepository>();

            return services;
        }
    }
}
