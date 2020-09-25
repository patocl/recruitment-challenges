using System.Collections.Generic;

namespace Refactoring.FraudDetection.Service.Contracts
{
    public interface IAuditor<in T, out TG>
    {
        IEnumerable<TG> Analyze(IEnumerable<T> collection);
    }
}