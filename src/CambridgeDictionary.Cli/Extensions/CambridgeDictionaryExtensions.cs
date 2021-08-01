using Microsoft.Extensions.DependencyInjection;
using ScrapySharp.Network;
using System.Net.Cache;
using System.Text;

namespace CambridgeDictionary.Cli.Extensions
{
    public static class CambridgeDictionaryExtensions
    {
        public static IServiceCollection AddCambridgeDictionary(this IServiceCollection services)
        {
            var policy =
                new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

            services.AddScoped<ICambridgeDictionaryCli, CambridgeDictionaryCli>(serviceProvider => {
                var dependency = serviceProvider.GetRequiredService<IScrapper>();
                return new CambridgeDictionaryCli(dependency);
            });
            services.AddScoped<IScrapper, Scrapper>();
            services.AddScoped(x => new ScrapingBrowser()
            {
                Encoding = Encoding.UTF8,
                CachePolicy = policy
            });

            return services;
        }
    }
}
