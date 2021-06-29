using Microsoft.Extensions.DependencyInjection;
using ScrapySharp.Network;
using System.Text;

namespace CambridgeDictionary.Cli.Extensions
{
    public static class CambridgeDictionaryExtensions
    {
        public static IServiceCollection AddCambridgeDictionary(this IServiceCollection services)
        {
            services.AddScoped<ICambridgeDictionaryCli, CambridgeDictionaryCli>();
            services.AddScoped<IScrapper, Scrapper>();
            services.AddScoped(x => new ScrapingBrowser()
            {
                Encoding = Encoding.UTF8
            });

            return services;
        }
    }
}
