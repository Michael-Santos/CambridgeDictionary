using Microsoft.Extensions.DependencyInjection;

namespace CambridgeDictionary.Cli.Extensions
{
    public static class CambridgeDictionaryExtensions
    {
        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICambridgeDictionaryCli, CambridgeDictionaryCli>();
        }
    }
}
