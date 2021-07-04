using CambridgeDictionary.Cli.Extensions;
using CambridgeDictionary.Cli.Test;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CambridgeDictionary.Cli.Debug
{
    public class Runner : IRunner
    {
        private IServiceProvider _serviceProvider;
        private ICambridgeDictionaryCli _cambridgeDictionary;

        public Runner()
        {
            ConfigureServices();
            _cambridgeDictionary = GetInstance();
        }

        public EntrySet Run(string word, bool useCache = true)
        {
            if (!useCache)
            {
                return _cambridgeDictionary.GetEntry(word);
            }
            
            var cacheManager = new FileCacheManager();

            if (!cacheManager.Exists(word))
            {
                var entry = _cambridgeDictionary.GetEntry(word);
                cacheManager.Write(word, entry.Raw);
                return entry;
            }

            var cachedPage = cacheManager.Read(word);
            return _cambridgeDictionary.GetEntryFromHtmlSource(cachedPage);
        }

        public List<EntrySet> RunRange(params string[] words)
        {
            var entries = new List<EntrySet>();

            foreach (string word in words)
            {
                entries.Add(Run(word));
            }

            return entries;
        }

        private void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCambridgeDictionary();

            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private ICambridgeDictionaryCli GetInstance()
        {
            return _serviceProvider.GetService<ICambridgeDictionaryCli>();
        }
    }
}
