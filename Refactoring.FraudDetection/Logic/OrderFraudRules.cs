using Refactoring.FraudDetection.Core.Specifications.Extensions;
using Refactoring.FraudDetection.Logic.Contracts;
using Refactoring.FraudDetection.Logic.OrderSpecifications;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Logic
{
    public class OrderFraudRules : IFraudRules<IOrder>
    {
        public bool IsFraud(IOrder order, IOrder current)
        {
            var distinctCreditCard = new DistinctCreditCardSpecification(order.CreditCard);
            var sameDealAddress = new SameDealAddressSpecification(order.DealAddress);
            var sameDealId = new SameDealIdSpecification(order.DealId);
            var sameMail = new SameEmailSpecification(order.Email);

            var rule1 = sameDealId
                .And(sameMail)
                .And(distinctCreditCard)
                .IsSatisfiedBy(current);

            var rule2 = sameDealId
                .And(distinctCreditCard)
                .IsSatisfiedBy(current) && sameDealAddress.IsSatisfiedBy(current.DealAddress);

            return rule1 || rule2;
        }
    }
}
