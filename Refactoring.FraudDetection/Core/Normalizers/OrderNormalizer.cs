using Refactoring.FraudDetection.Core.Entities;
using Refactoring.FraudDetection.Core.Interfaces;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class OrderNormalizer :IOrderNormalizer
    {
        NormalizerFactory _normalizerFactory;
        public OrderNormalizer(NormalizerFactory normalizerFactory)
        {
            this._normalizerFactory = normalizerFactory;
        }
        public void Normalize(List<Order> orders)
        {
            foreach (var order in orders)
            {
                this._normalizerFactory.Normalize(order);
            }
        }
    }
}
