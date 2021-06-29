using CambridgeDictionary.Cli;
using CambridgeDictionary.Cli.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CambridgeDictionay.Cli.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            CambridgeDictionaryExtensions.ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var cambridgeDictionary = serviceProvider.GetService<ICambridgeDictionaryCli>();

            var word = "put";

            cambridgeDictionary.GetMeaning(word);

        }
    }
}
