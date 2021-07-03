using System.IO;

namespace CambridgeDictionary.Cli.Test
{
    public class FileManager : IFileManager
    {
        const string basePath = "";
        private readonly string _filePath;

        public FileManager(string name)
        {
            _filePath = Path.Combine(basePath, name);
        }

        public void Create(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string name)
        {
            throw new System.NotImplementedException();
        }

        public string Read(string name)
        {
            throw new System.NotImplementedException();
        }

        public void Write(string name, string content)
        {
            throw new System.NotImplementedException();
        }
    }
}
