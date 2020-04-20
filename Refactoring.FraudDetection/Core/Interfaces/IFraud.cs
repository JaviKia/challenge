using Refactoring.FraudDetection.Core.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Interfaces
{
    public interface IFraud
    {
        List<FraudResult> DetectFrauds(List<Order> orders);
    }
}