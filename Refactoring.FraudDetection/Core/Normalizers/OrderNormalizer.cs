using Refactoring.FraudDetection.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public class OrderNormalizer :IOrderNormalizer
    {
        public void Normalize(List<Order> orders)
        {
            var normalizers = from t in Assembly.GetExecutingAssembly().GetTypes()
                              where t.GetInterfaces().Contains(typeof(ISimpleNormalizer))
                                       && t.GetConstructor(Type.EmptyTypes) != null
                              select Activator.CreateInstance(t) as ISimpleNormalizer;

            foreach (var order in orders)
            {
                foreach (var normalizer in normalizers)
                {
                    normalizer.Normalize(order);
                }
            }
        }
    }
}
