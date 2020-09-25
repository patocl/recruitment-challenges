using System;
using Refactoring.FraudDetection.Core.Specifications.Contracts;

namespace Refactoring.FraudDetection.Core.Specifications
{
    public class OrSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly ISpecification<TEntity> leftSpecification;
        private readonly ISpecification<TEntity> rightSpecification;

        public OrSpecification(ISpecification<TEntity> leftSpecification, ISpecification<TEntity> rightSpecification)
        {
            this.leftSpecification = leftSpecification ?? throw new ArgumentNullException(nameof(leftSpecification));
            this.rightSpecification = rightSpecification ?? throw new ArgumentNullException(nameof(leftSpecification));
        }

        public bool IsSatisfiedBy(TEntity candidate) 
            => leftSpecification.IsSatisfiedBy(candidate) || rightSpecification.IsSatisfiedBy(candidate);
    }
}
