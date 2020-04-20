using Refactoring.FraudDetection.Core.Entities;
using Refactoring.FraudDetection.Core.Interfaces;
using Refactoring.FraudDetection.Core.Normalizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class NormalizerFactory : INormalizerFactory
    {
        IEnumerable<ISimpleNormalizer> _normalizers;
        public NormalizerFactory()
        {
            _normalizers = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where t.GetInterfaces().Contains(typeof(ISimpleNormalizer))
                                       && t.GetConstructor(Type.EmptyTypes) != null
                              select Activator.CreateInstance(t) as ISimpleNormalizer;
        }

        public void Normalize(Order order)
        {
            foreach (var normalizer in _normalizers)
            {
                normalizer.Normalize(order);
            }
        }
    }
}
