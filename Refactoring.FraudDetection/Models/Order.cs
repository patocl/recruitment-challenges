// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

using Refactoring.FraudDetection.Models.Contracts;
using System;

namespace Refactoring.FraudDetection.Models
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string CreditCard { get; set; }

        public Address DealAddress { get; set; }

        public override bool Equals(object obj)
        {
            if (GetType() != obj?.GetType())
                return false;

            var order = (Order)obj;
            
            return OrderId == order.OrderId
                && DealId == order.DealId
                && Email == order.Email
                && CreditCard == order.CreditCard
                && DealAddress == order.DealAddress;
        }

        public override int GetHashCode() 
            => Tuple.Create(OrderId, DealId, Email, CreditCard, DealAddress).GetHashCode();
    }
}