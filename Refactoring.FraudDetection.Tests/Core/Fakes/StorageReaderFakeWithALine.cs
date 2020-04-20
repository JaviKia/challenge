using Refactoring.FraudDetection.Core;

namespace Refactoring.FraudDetection.Tests.Core.Fakes
{
    public class StorageReaderFakeWithALine : StorageReader
    {
        public StorageReaderFakeWithALine(string filePath):base(filePath)
        {

        }
        public override string[] ReadFile()
        {
            return new string[] { "1,1,bugs@bunny.com,123 Sesame St.,New York,NY,10011,12345689010" };
        }
    }
}
