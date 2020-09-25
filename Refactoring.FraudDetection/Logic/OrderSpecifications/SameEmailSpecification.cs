using Refactoring.FraudDetection.Core.Specifications.Contracts;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Logic.OrderSpecifications
{
    public class SameEmailSpecification : ISpecification<IOrder>
    {
        public string Email { get; }

        public SameEmailSpecification(string email) => Email = email;

        public bool IsSatisfiedBy(IOrder order) => Email == order.Email;
    }
}
