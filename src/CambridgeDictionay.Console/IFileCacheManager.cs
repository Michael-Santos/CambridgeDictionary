namespace CambridgeDictionary.Cli.Test
{
    public interface IFileCacheManager
    {
        public void Delete(string name);
        public bool Exists(string name);
        public string Read(string name);
        public void Write(string name, string content);
    }
}
