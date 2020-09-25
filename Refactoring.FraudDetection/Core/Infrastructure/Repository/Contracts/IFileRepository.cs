using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts
{
    public interface IFileRepository<out T>
    {
        IEnumerable<T> GetAll(IFileReader fileReader);
    }
}
