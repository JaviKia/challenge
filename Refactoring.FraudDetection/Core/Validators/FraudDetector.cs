using Refactoring.FraudDetection.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Refactoring.FraudDetection.Core.Validators
{
    public class FraudDetector :IFraud
    {
        public List<FraudResult> DetectFrauds(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();

            var validators = from t in Assembly.GetExecutingAssembly().GetTypes()
                             where !(!t.GetInterfaces().Contains(typeof(ISimpleValidator))
                                      || t.GetConstructor(Type.EmptyTypes) == null)
                             select Activator.CreateInstance(t) as ISimpleValidator;


            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = i + 1; j < orders.Count; j++)
                {
                    if (IsThereFraud(validators.ToList(), orders[i], orders[j]))
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }

        private bool IsThereFraud(List<ISimpleValidator> validators, Order currentOrder, Order otherOrder)
        {
            int i = 0;
            bool isFraudulent = false;
            while (!isFraudulent && i < validators.Count() -1)
            {
                isFraudulent = validators[i].Validate(currentOrder, otherOrder);
                i++; 
            }

            return isFraudulent;
        }
    }
}
