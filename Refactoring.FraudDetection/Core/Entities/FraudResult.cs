using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Core.Entities
{
    public class FraudResult
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }
    }
}
