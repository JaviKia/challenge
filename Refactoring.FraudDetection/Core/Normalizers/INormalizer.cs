﻿using Refactoring.FraudDetection.Core.Entities;

namespace Refactoring.FraudDetection.Core.Normalizers
{
    public interface ISimpleNormalizer
    {
        void Normalize(Order order);
    }
}