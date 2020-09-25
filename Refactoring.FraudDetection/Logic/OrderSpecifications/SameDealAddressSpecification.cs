using Refactoring.FraudDetection.Core.Specifications.Contracts;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Logic.OrderSpecifications
{
    public class SameDealAddressSpecification : ISpecification<IAddress>
    {
        public IAddress DealAddress { get; }

        public SameDealAddressSpecification(IAddress dealAddress) => DealAddress = dealAddress;

        public bool IsSatisfiedBy(IAddress address) => address.Equals(DealAddress); //Equals override ;)
    }
}