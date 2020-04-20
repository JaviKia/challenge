using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Interfaces
{
    public interface ISimpleValidator
    {
        bool Validate(Order currentOrder, Order otherOrder);
    }
}