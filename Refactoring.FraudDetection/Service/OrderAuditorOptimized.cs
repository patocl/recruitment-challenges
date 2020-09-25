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

    public class OrderAuditorOptimized : IAuditor<IOrder, IFraudResult>
    {
        public OrderAuditorOptimized() => OrderRules = new OrderFraudRules();

        public OrderAuditorOptimized(IFraudRules<IOrder> orderRules) => OrderRules = orderRules;

        public IFraudRules<IOrder> OrderRules { get; set; }


        // NOTE: I don't recommend to use this approach to files too bigger (objects are on memory)
        public IEnumerable<IFraudResult> Analyze(IEnumerable<IOrder> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var results = new List<IFraudResult>();

            var orderList = collection.ToList();
            if (orderList.Count < 2) // just 1 order, can't be frauds!
                return results;

            var orders = orderList
                .OrderBy(p=>p.DealId)
                .ThenBy(p => p.OrderId).ToList(); // Assumption that the first Order ever is OK

            var deals = orders.GroupBy(o => o.DealId);

            foreach (var key in deals)
            {
                if (key.Count() == 1)
                    continue;
                
                var order = key.First();

                results.AddRange(key.Where(p => !p.Equals(order))
                    .Where(current => OrderRules.IsFraud(order, current))
                    .Select(current => 
                        new FraudResult
                        {
                            IsFraudulent = true, 
                            OrderId = current.OrderId
                        }));
            }

            return results;
        }
    }
}