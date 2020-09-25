// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection.Models.Contracts
{
    public interface IOrder
    {
        string CreditCard { get; set; }
        Address DealAddress { get; set; }
        int DealId { get; set; }
        string Email { get; set; }
        int OrderId { get; set; }
    }
}