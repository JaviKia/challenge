using static Refactoring.FraudDetection.FraudRadar;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public interface INormalizer
    {
        void Normalize(Order order);
    }
}