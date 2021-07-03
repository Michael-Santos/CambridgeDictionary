namespace CambridgeDictionary.Cli.Test
{
    public interface IFileManager
    {
        public void Create(string name);
        public void Delete(string name);
        public bool Exists(string name);
        public string Read(string name);
        public void Write(string name, string content);
    }
}
