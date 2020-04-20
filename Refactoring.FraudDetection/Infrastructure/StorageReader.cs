using Refactoring.FraudDetection.Core.Interfaces;
using Refactoring.FraudDetection.Core.Entities;
using System.Collections.Generic;
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
        public List<Order> Read()
        {
            var orders = new List<Order>();

            string[] lines = ReadFile();

            if (lines != null)
            {
                foreach (var line in lines)
                {
                    orders.Add(new Order(line));
                }
            }
            return orders;
        }

        public virtual string[] ReadFile()
        {
            return File.ReadAllLines(_filePath);
        }
    }
}
