using CambridgeDictionary.Cli;
using CambridgeDictionary.Cli.Extensions;
using CambridgeDictionary.Cli.Test;
using Microsoft.Extensions.DependencyInjection;

namespace CambridgeDictionay.Cli.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var word1 = "pull someone’s leg";
            var word2 = "at the expense of someone";
            var word3 = "pencil";
            var word4 = "pull";

            var result1 = Runner(word1);
            var result2 = Runner(word2);
            var result3 = Runner(word3);
            var result4 = Runner(word4);
        }


        private static EntrySet Runner(string word)
        {
            var cambridgeDictionary = GetCambridgeDicionaryCliInstance();

            var entry = cambridgeDictionary.GetEntry(word);
            var cacheManager = new FileCacheManager();

            if (!cacheManager.Exists(word))
            {
                cacheManager.Write(word, entry.Raw);
                return entry;
            }

            var cachedPage = cacheManager.Read(word);
            return cambridgeDictionary.GetMeaningFromHtmlSource(cachedPage);
        }

        private static ICambridgeDictionaryCli GetCambridgeDicionaryCliInstance()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCambridgeDictionary();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<ICambridgeDictionaryCli>();
        }
    }
}
