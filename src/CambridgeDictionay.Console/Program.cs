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

            //var word = "pull someone's leg";
            //var word1 = "pull someone’s leg";
            //var word2 = "at the expense of someone";
            //var word3 = "pencil";
            //var word4 = "pull";

            //var result1 = cambridgeDictionary.GetMeaning(word1);
            //var result2 = cambridgeDictionary.GetMeaning(word2);
            //var result3 = cambridgeDictionary.GetMeaning(word3);
            //var result4 = cambridgeDictionary.GetMeaning(word4);

            var word = "pulla";
            var result = cambridgeDictionary.GetMeaning(word);
        }
    }
}
