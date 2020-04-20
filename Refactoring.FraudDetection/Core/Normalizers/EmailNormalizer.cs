using System;
using static Refactoring.FraudDetection.FraudRadar;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class EmailNormalizer :INormalizer
    {
        public void Normalize(Order order)
        {
            var aux = order.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            order.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
