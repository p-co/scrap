using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrap.Services.Abstractions;
using Scrap.Services.Abstractions.Mappers;
using Scrap.Services.Mappers;

namespace Scrap.Services.Extensions.DependencyInjection
{
    public static class ScraperServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IScraperService, ScraperService>();

            services.AddTransient<ICollectedInfoMapper, CollectedInfoMapper>();

            services.AddSingleton<IWebDriver, ChromeDriver>();

            return services;
        }
    }
}
