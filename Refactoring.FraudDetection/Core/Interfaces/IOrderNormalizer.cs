using Refactoring.FraudDetection.Core.Entities;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Interfaces
{
    public interface IOrderNormalizer
    {
        void Normalize(List<Order> orders);
    }
}