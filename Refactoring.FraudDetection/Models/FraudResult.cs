// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Models
{
    public class FraudResult : IFraudResult
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }
    }
}