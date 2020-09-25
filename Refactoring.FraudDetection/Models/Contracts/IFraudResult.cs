// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection.Models.Contracts
{
    public interface IFraudResult
    {
        bool IsFraudulent { get; set; }
        int OrderId { get; set; }
    }
}