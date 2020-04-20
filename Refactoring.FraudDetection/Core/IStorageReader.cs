using Refactoring.FraudDetection.Core.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core
{
    public interface IStorageReader
    {
        List<Order> Read();
    }
}
