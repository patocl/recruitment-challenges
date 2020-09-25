using Refactoring.FraudDetection.Core.Specifications.Contracts;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Logic.OrderSpecifications
{
    public class SameDealIdSpecification : ISpecification<IOrder>
    {
        public int DealId { get; set; }

        public SameDealIdSpecification(int dealId) => DealId = dealId;

        public bool IsSatisfiedBy(IOrder order) => DealId == order.DealId;
    }
}