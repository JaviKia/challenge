using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class StateNormalizer : ISimpleNormalizer
    {
        public void Normalize(Order order)
        {
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
    }
}
