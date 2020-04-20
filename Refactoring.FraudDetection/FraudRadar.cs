// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Core;
    using Refactoring.FraudDetection.Core.Entities;
    using Refactoring.FraudDetection.Core.Normalizers;
    using Refactoring.FraudDetection.Core.Validators;
    using System.Collections.Generic;

    public class FraudRadar
    {
        private IStorageReader _storageReader;
        private IOrderNormalizer _orderNormalizer;
        private IFraud _fraud;

        public FraudRadar(IOrderNormalizer orderNormalizer, IFraud fraud, IStorageReader storageReader)
        {
            this._storageReader = storageReader;
            this._orderNormalizer = orderNormalizer;
            this._fraud = fraud;
        }
        public IEnumerable<FraudResult> Check()
        {            
            var orders = this._storageReader.Read();
            this._orderNormalizer.Normalize(orders);
            return this._fraud.DetectFrauds(orders);
        }

    }
}