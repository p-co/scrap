using Microsoft.Extensions.DependencyInjection;
using Scrap.Repositories.Extensions.DependencyInjection;
using Scrap.Services.Abstractions;
using Scrap.Services.Extensions.DependencyInjection;

namespace Scrap.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var scraperService = serviceProvider.GetService<IScraperService>();
            scraperService!.ScrapeAll();

            if (serviceProvider is IDisposable disposable)
                disposable.Dispose();
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddServices();
            serviceCollection.AddRepositories();
        }
    }
}