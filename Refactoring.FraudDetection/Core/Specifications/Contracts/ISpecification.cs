namespace Refactoring.FraudDetection.Core.Specifications.Contracts
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
