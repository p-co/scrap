using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrap.Services.Abstractions;

namespace Scrap.Services.Extensions.DependencyInjection
{
    public static class ScraperServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IScraperService, ScraperService>();

            services.AddSingleton<IWebDriver, ChromeDriver>();

            return services;
        }
    }
}
