using Refactoring.FraudDetection.Core;

namespace Refactoring.FraudDetection.Tests.Core.Fakes
{
    public class StorageReaderFakeNull : StorageReader
    {
        public StorageReaderFakeNull(string filePath):base(filePath)
        {

        }
        public override string[] ReadFile()
        {
            return null;
        }
    }
}
