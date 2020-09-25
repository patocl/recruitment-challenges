using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Infrastructure.Normalizer.Contracts
{
    public interface INormalizer<TEntity>
    {
        IEnumerable<TEntity> Apply(IEnumerable<TEntity> entity);
    }
}
