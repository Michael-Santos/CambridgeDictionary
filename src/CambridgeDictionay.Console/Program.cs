using CambridgeDictionary.Cli;
using CambridgeDictionary.Cli.Extensions;
using CambridgeDictionary.Cli.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CambridgeDictionay.Cli.Debug
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            ConfigureService();

            var result1 = RunTestsInTheSameMethodManyTimes(1);
            var result2 = RunTestManyTimes(5);
        }


        private static EntrySet Runner(string word)
        {
            var cambridgeDictionary = GetCambridgeDictionaryCliInstance();

            var cacheManager = new FileCacheManager();

            if (!cacheManager.Exists(word))
            {
                var entry = cambridgeDictionary.GetEntry(word);
                cacheManager.Write(word, entry.Raw);
                return entry;
            }

            var cachedPage = cacheManager.Read(word);
            return cambridgeDictionary.GetEntryFromHtmlSource(cachedPage);
        }

        private static void ConfigureService()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCambridgeDictionary();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static ICambridgeDictionaryCli GetCambridgeDictionaryCliInstance()
        {
            return _serviceProvider.GetService<ICambridgeDictionaryCli>();
        }

        private static void BeforeGCCollect()
        {
            Console.WriteLine("Memory used before collection:       {0:N0}",
                              GC.GetTotalMemory(false));
        }

        private static void AfterGCCollect()
        {
            Console.WriteLine("Memory used after full collection:   {0:N0}",
                        GC.GetTotalMemory(true));
        }


        private static List<EntrySet> RunTest()
        {
            var word1 = "pull";
            var word2 = "at the expense of someone";
            var word3 = "pencil";
            var word4 = "pull someone’s leg";
            var word5 = "tandem";
            var word6 = "ramble";
            var word7 = "blunt";
            var word8 = "glance";
            var word9 = "will";
            var word10 = "volition";

            var entrySetList = new List<EntrySet>();

            entrySetList.Add(Runner(word1));
            entrySetList.Add(Runner(word2));
            entrySetList.Add(Runner(word3));
            entrySetList.Add(Runner(word4));
            entrySetList.Add(Runner(word5));
            entrySetList.Add(Runner(word6));
            entrySetList.Add(Runner(word7));
            entrySetList.Add(Runner(word8));
            entrySetList.Add(Runner(word9));
            entrySetList.Add(Runner(word10));
            BeforeGCCollect();
            GC.Collect();
            AfterGCCollect();

            return entrySetList;
        }

        private static List<EntrySet> RunTestManyTimes(int times)
        {
            var entrySetList = new List<EntrySet>();

            for (int i=0; i < times; i++)
            {
                entrySetList.AddRange(RunTest());
            }

            return entrySetList;
        }

        private static List<EntrySet> RunTestsInTheSameMethodManyTimes(int times)
        {
            var word1 = "pull";
            var word2 = "at the expense of someone";
            var word3 = "pencil";
            var word4 = "pull someone’s leg";
            var word5 = "tandem";
            var word6 = "ramble";
            var word7 = "blunt";
            var word8 = "glance";
            var word9 = "will";
            var word10 = "volition";

            var entrySetList = new List<EntrySet>();

            for (int i=0; i < times; i++)
            {
                entrySetList.Add(Runner(word1));
                entrySetList.Add(Runner(word2));
                entrySetList.Add(Runner(word3));
                entrySetList.Add(Runner(word4));
                entrySetList.Add(Runner(word5));
                entrySetList.Add(Runner(word6));
                entrySetList.Add(Runner(word7));
                entrySetList.Add(Runner(word8));
                entrySetList.Add(Runner(word9));
                entrySetList.Add(Runner(word10));
                BeforeGCCollect();
                GC.Collect();
                AfterGCCollect();

                entrySetList.Add(Runner(word1));
                entrySetList.Add(Runner(word2));
                entrySetList.Add(Runner(word3));
                entrySetList.Add(Runner(word4));
                entrySetList.Add(Runner(word5));
                entrySetList.Add(Runner(word6));
                entrySetList.Add(Runner(word7));
                entrySetList.Add(Runner(word8));
                entrySetList.Add(Runner(word9));
                entrySetList.Add(Runner(word10));
                BeforeGCCollect();
                GC.Collect();
                AfterGCCollect();

                entrySetList.Add(Runner(word1));
                entrySetList.Add(Runner(word2));
                entrySetList.Add(Runner(word3));
                entrySetList.Add(Runner(word4));
                entrySetList.Add(Runner(word5));
                entrySetList.Add(Runner(word6));
                entrySetList.Add(Runner(word7));
                entrySetList.Add(Runner(word8));
                entrySetList.Add(Runner(word9));
                entrySetList.Add(Runner(word10));
                BeforeGCCollect();
                GC.Collect();
                AfterGCCollect();

                entrySetList.Add(Runner(word1));
                entrySetList.Add(Runner(word2));
                entrySetList.Add(Runner(word3));
                entrySetList.Add(Runner(word4));
                entrySetList.Add(Runner(word5));
                entrySetList.Add(Runner(word6));
                entrySetList.Add(Runner(word7));
                entrySetList.Add(Runner(word8));
                entrySetList.Add(Runner(word9));
                entrySetList.Add(Runner(word10));
                BeforeGCCollect();
                GC.Collect();
                AfterGCCollect();
            }

            return entrySetList;
        }
    }
}
