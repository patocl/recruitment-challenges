using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts
{
    public interface IObjectBuilder<out T>
    {
        IEnumerable<T> Create(string[] lines);
        T CreateOne(string line);
    }
}
