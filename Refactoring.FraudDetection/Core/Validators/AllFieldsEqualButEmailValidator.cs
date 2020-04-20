using Refactoring.FraudDetection.Core.Entities;
using Refactoring.FraudDetection.Core.Interfaces;

namespace Refactoring.FraudDetection.Core.Validators
{
    public class AllFieldsEqualButEmailValidator : ISimpleValidator
    {
        public bool Validate(Order currentOrder, Order otherOrder)
        {
            if (currentOrder.DealId == otherOrder.DealId
                && currentOrder.State == otherOrder.State
                && currentOrder.ZipCode == otherOrder.ZipCode
                && currentOrder.Street == otherOrder.Street
                && currentOrder.City == otherOrder.City
                && currentOrder.CreditCard != otherOrder.CreditCard)
            {
                return true;
            }
            return false;
        }
    }
}
