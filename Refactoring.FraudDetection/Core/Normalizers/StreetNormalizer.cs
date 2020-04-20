namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class StreetNormalizer : INormalizer
    {
        public void Normalize(FraudRadar.Order order)
        {
            order.Street = order.Street.Replace("st.", "street").Replace("rd.", "road");
        }
    }
}
