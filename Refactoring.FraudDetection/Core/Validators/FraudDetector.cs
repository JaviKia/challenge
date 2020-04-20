using Refactoring.FraudDetection.Core.Entities;
using Refactoring.FraudDetection.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Refactoring.FraudDetection.Core.Validators
{
    public class FraudDetector :IFraud
    {
        ValidatorFactory _validatorFactory;

        public FraudDetector(ValidatorFactory validatorFactory)
        {
            this._validatorFactory = validatorFactory;
        }
        public List<FraudResult> DetectFrauds(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();            

            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = i + 1; j < orders.Count; j++)
                {
                    if (this._validatorFactory.Validate(orders[i], orders[j]))
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }
            return fraudResults;
        }
    }
}
