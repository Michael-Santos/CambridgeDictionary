using Microsoft.Extensions.DependencyInjection;
using ScrapySharp.Network;
using System.Text;

namespace CambridgeDictionary.Cli.Extensions
{
    public static class CambridgeDictionaryExtensions
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICambridgeDictionaryCli, CambridgeDictionaryCli>();
            serviceCollection.AddScoped<IScrapper, Scrapper>();
            serviceCollection.AddScoped(x => new ScrapingBrowser()
            {
                Encoding = Encoding.UTF8
            });
        }
    }
}
