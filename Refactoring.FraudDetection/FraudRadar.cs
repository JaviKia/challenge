// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Core;
    using Refactoring.FraudDetection.Core.Entities;
    using Refactoring.FraudDetection.Core.Normalizers;
    using System;
    using System.Collections.Generic;

    public class FraudRadar
    {
        private IStorageReader _storageReader;
        private IOrderNormalizer _orderNormalizer;

        public FraudRadar(IOrderNormalizer orderNormalizer, IStorageReader storageReader)
        {
            this._storageReader = storageReader;
            this._orderNormalizer = orderNormalizer;
        }
        public IEnumerable<FraudResult> Check()
        {
            // READ FRAUD LINES
            var orders = new List<Order>();
            var fraudResults = new List<FraudResult>();

            var lines = this._storageReader.Read();

            foreach (var line in lines)
            {
                orders.Add(new Order(line));
            }

            this._orderNormalizer.Normalize(orders);

            // CHECK FRAUD
            for (int i = 0; i < orders.Count; i++)
            {
                var current = orders[i];
                bool isFraudulent = false;

                for (int j = i + 1; j < orders.Count; j++)
                {
                    isFraudulent = false;

                    if (current.DealId == orders[j].DealId
                        && current.Email == orders[j].Email
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (current.DealId == orders[j].DealId
                        && current.State == orders[j].State
                        && current.ZipCode == orders[j].ZipCode
                        && current.Street == orders[j].Street
                        && current.City == orders[j].City
                        && current.CreditCard != orders[j].CreditCard)
                    {
                        isFraudulent = true;
                    }

                    if (isFraudulent)
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orders[j].OrderId });
                    }
                }
            }

            return fraudResults;
        }

    }
}