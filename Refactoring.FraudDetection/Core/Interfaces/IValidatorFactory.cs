using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Intefaces
{
    public interface IValidatorFactory
    {
        bool Validate(Order currentOrder, Order otherOrder);
    }
}