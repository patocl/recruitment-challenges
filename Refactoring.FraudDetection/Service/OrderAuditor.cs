using System;
using Refactoring.FraudDetection.Service.Contracts;
using Refactoring.FraudDetection.Logic;
using Refactoring.FraudDetection.Logic.Contracts;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Refactoring.FraudDetection.Service
{
    public class OrderAuditor : IAuditor<IOrder, IFraudResult>
    {
        public OrderAuditor() => OrderRules = new OrderFraudRules();

        public OrderAuditor(IFraudRules<IOrder> orderRules) => OrderRules = orderRules;

        public IFraudRules<IOrder> OrderRules { get; set; }

        public IEnumerable<IFraudResult> Analyze(IEnumerable<IOrder> collection)
        {
            if(collection == null)
                throw new ArgumentNullException(nameof(collection));

            var results = new List<IFraudResult>();
            var orders = collection.ToList();

            for (var i = 0; i < orders.ToArray().Length; i++)
            {
                var current = orders[i];

                for (var j = i + 1; j < orders.Count; j++)
                {
                    if (OrderRules.IsFraud(current, orders[j]))
                    {
                        results.Add(
                            new FraudResult {
                                IsFraudulent = true,
                                OrderId = orders[j].OrderId
                            });
                    }
                }
            }
            return results;
        }
    }
}