using Refactoring.FraudDetection.Core.Specifications.Contracts;

namespace Refactoring.FraudDetection.Logic.OrderSpecifications
{
    using Refactoring.FraudDetection.Models.Contracts;

    public class DistinctCreditCardSpecification : ISpecification<IOrder>
    {
        public string CreditCard { get; }

        public DistinctCreditCardSpecification(string creditCard) => CreditCard = creditCard;

        public bool IsSatisfiedBy(IOrder order)  => CreditCard != order.CreditCard;
    }
}
