using System.IO;

namespace AddressApi.DataAccess
{
    public class FileHandler
    {
        private string _filePath;

        public FileHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveToFile(string data)
        {
            File.AppendAllText(_filePath, data + Environment.NewLine);
        }

        public string[] ReadFile()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
