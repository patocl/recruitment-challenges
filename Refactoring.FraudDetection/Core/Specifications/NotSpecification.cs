using System;
using Refactoring.FraudDetection.Core.Specifications.Contracts;

namespace Refactoring.FraudDetection.Core.Specifications
{
    public class NotSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> specification;

        public NotSpecification(ISpecification<TEntity> notSpecification)
            => specification = notSpecification ?? throw new ArgumentNullException(nameof(specification));

        public bool IsSatisfiedBy(TEntity candidate) => !specification.IsSatisfiedBy(candidate);
    }
}
