using Refactoring.FraudDetection.Core.Infrastructure.Builder;
using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using Refactoring.FraudDetection.Models.Contracts;
using System.Collections.Generic;

namespace Refactoring.FraudDetection.Core.Infrastructure.Repository
{
    public class OrderFileRepository : IFileRepository<IOrder>
    {
        public OrderFileRepository() => Builder = new OrderBuilder();

        public OrderFileRepository(IObjectBuilder<IOrder> builder) => Builder = builder;

        public IObjectBuilder<IOrder> Builder { get; }
        
        public IEnumerable<IOrder> GetAll(IFileReader fileReader) => Builder.Create(fileReader.ReadAllLines());
    }
}
