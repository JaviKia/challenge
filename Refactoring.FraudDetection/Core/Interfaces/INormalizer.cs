using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Interfaces
{
    public interface ISimpleNormalizer
    {
        void Normalize(Order order);
    }
}