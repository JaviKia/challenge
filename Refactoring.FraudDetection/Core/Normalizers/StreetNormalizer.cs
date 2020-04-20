using Refactoring.FraudDetection.Core.Interfaces;
using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class StreetNormalizer : ISimpleNormalizer
    {
        public void Normalize(Order order)
        {
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");
        }
    }
}
