using System;
using System.Collections.Generic;
using System.Text.Json;
using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Core.Infrastructure.Repository
{
    public class OrderJsonRepository : IFileRepository<IOrder>
    {
        public IEnumerable<IOrder> GetAll(IFileReader fileReader) 
            => GetJsonGenericType<List<Order>>(fileReader.ReadAllText());

        private static T GetJsonGenericType<T>(string json) 
            => (T)Convert.ChangeType(JsonSerializer.Deserialize<T>(json), typeof(T));
    }
}
