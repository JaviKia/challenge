using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Validators
{
    public class SameDealIdAndEmailButDifferentCreditCardValidator :ISimpleValidator
    {
        public bool Validate(Order currentOrder, Order otherOrder)
        {
            if (currentOrder.DealId == otherOrder.DealId
                && currentOrder.Email == otherOrder.Email
                && currentOrder.CreditCard != otherOrder.CreditCard)
            {
                return true;
            }
            return false;
        }
    }
}
