using System.IO;

namespace CambridgeDictionary.Cli.Test
{
    public class FileCacheManager : IFileCacheManager
    {
        const string basePath = "";

        public FileCacheManager()
        {
            
        }

        public void Delete(string name)
        {
            if (Exists(name))
            {
                File.Delete(name);
            }
        }

        public bool Exists(string name) => File.Exists(GetFilePath(name));

        public string Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string name, string content)
        {
            throw new System.NotImplementedException();
        }

        private string GetFilePath(string name) => Path.Combine(basePath, name);
    }
}
