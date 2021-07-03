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
            

            //var word1 = "pull someone’s leg";
            //var word2 = "at the expense of someone";
            //var word3 = "pencil";
            //var word4 = "pull";

            //var result1 = cambridgeDictionary.GetMeaning(word1);
            //var result2 = cambridgeDictionary.GetMeaning(word2);
            //var result3 = cambridgeDictionary.GetMeaning(word3);
            //var result4 = cambridgeDictionary.GetMeaning(word4);

            var word = "pull";
            



            //cambridgeDictionary = new CambridgeDictionaryCli();
            //result = cambridgeDictionary.GetEntry(word);
        }


        private static string Runner(string word)
        {
            var cambridgeDictionary = GetCambridgeDicionaryCliInstance();

            var entry = cambridgeDictionary.GetEntry(word);
            var cacheManager = new FileCacheManager();

            if (!cacheManager.Exists(word))
            {
                cacheManager.Write(word, entry.Raw);
            }

             return cacheManager.Read(word);
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
