using Refactoring.FraudDetection.Core;

namespace Refactoring.FraudDetection.Tests.Core.Fakes
{
    public class StorageReaderFakeWithoutLines : StorageReader
    {
        public StorageReaderFakeWithoutLines(string filePath):base(filePath)
        {

        }
        public override string[] ReadFile()
        {
            return new string[] {  };
        }
    }
}
