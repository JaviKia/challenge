using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Validators
{
    public interface ISimpleValidator
    {
        bool Validate(Order currentOrder, Order otherOrder);
    }
}