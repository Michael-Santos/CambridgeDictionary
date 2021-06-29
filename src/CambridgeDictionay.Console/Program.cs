using CambridgeDictionary.Cli;
using CambridgeDictionary.Cli.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace CambridgeDictionay.Cli.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCambridgeDictionary();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var cambridgeDictionary = serviceProvider.GetService<ICambridgeDictionaryCli>();

            var word = "pull someone's leg";

            var result = cambridgeDictionary.GetMeaning(word);
        }
    }
}
