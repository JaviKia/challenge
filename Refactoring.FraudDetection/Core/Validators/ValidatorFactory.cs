using Refactoring.FraudDetection.Core.Entities;
using Refactoring.FraudDetection.Core.Intefaces;
using Refactoring.FraudDetection.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Refactoring.FraudDetection.Core.Validators
{
    public class ValidatorFactory : IValidatorFactory
    {
        List<ISimpleValidator> _validators;

        public ValidatorFactory()
        {
            _validators = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => !(!t.GetInterfaces().Contains(typeof(ISimpleValidator))
                                  || t.GetConstructor(Type.EmptyTypes) == null))
                        .Select(t => Activator.CreateInstance(t) as ISimpleValidator)
                        .ToList();
        }

        public bool Validate(Order currentOrder, Order otherOrder)
        {
            int i = 0;
            bool isFraudulent = false;
            while (!isFraudulent && i < _validators.Count() - 1)
            {
                isFraudulent = _validators[i].Validate(currentOrder, otherOrder);
                i++;
            }

            return isFraudulent;
        }
    }
}
