using Refactoring.FraudDetection.Core.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Validators
{
    public interface IFraud
    {
        List<FraudResult> DetectFrauds(List<Order> orders);
    }
}