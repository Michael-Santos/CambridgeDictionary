using System.IO;
using System.Text;

namespace CambridgeDictionary.Cli.Test
{
    public class FileCacheManager : IFileCacheManager
    {
        private const string CacheFolderName = "Cache";
        private string _basePath;

        public FileCacheManager()
        {
            _basePath = Path.GetFullPath("../../../" + CacheFolderName);
            Directory.CreateDirectory(_basePath);
        }

        public void Delete(string name)
        {
            if (Exists(name))
            {
                File.Delete(name);
            }

            throw new IOException("File was not found");
        }

        public bool Exists(string name) => File.Exists(GetFilePath(name));

        public string Read(string name)
        {
            string text = null;

            if (!Exists(name))
            {
                 text = File.ReadAllText(GetFilePath(name), Encoding.UTF8);
            }

            return text;
        }

        public void Write(string name, string content)
        {

            File.WriteAllText(GetFilePath(name), content, Encoding.UTF8);
        }

        private string GetFilePath(string name) => Path.Combine(_basePath, name);
    }
}
