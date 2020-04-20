using System.IO;

namespace Refactoring.FraudDetection.Core
{
    public class StorageReader : IStorageReader
    {
        string _filePath = null;
        public StorageReader(string filePath)
        {
            this._filePath = filePath;
        }
        public string[] Read()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
