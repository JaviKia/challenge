namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class StateNormalizer : INormalizer
    {
        public void Normalize(FraudRadar.Order order)
        {
            order.State = order.State.Replace("il", "illinois").Replace("ca", "california").Replace("ny", "new york");
        }
    }
}
