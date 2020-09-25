using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.StandardFormats;
using Refactoring.FraudDetection.Models;
using Refactoring.FraudDetection.Models.Contracts;

namespace Refactoring.FraudDetection.Core.Infrastructure.Builder
{
    public class OrderBuilder : IObjectBuilder<IOrder>
    {
        public IPropertyBuilder<int> IntProperty { get; set; }
        public IPropertyBuilder<string> StringProperty { get; set; }

        public OrderBuilder()
        {
            IntProperty = new IntProperty();
            StringProperty = new StringProperty();
        }

        public OrderBuilder(IPropertyBuilder<int> intProperty, IPropertyBuilder<string> stringProperty) 
        {
            IntProperty = intProperty ?? throw new ArgumentNullException(nameof(intProperty));
            StringProperty = stringProperty ?? throw new ArgumentNullException(nameof(stringProperty));
        }

        public IEnumerable<IOrder> Create(string[] lines) => lines.Select(CreateOne).ToList();

        public IOrder CreateOne(string line)
        {
            if (line == null)
                throw new ArgumentNullException(nameof(line));

            var orderProperties = line.Split(',');

            if (orderProperties.Length != 8)
                throw new ArgumentOutOfRangeException(nameof(line));

            return new Order
            {
                OrderId = IntProperty.Create(orderProperties[0]),
                DealId = IntProperty.Create(orderProperties[1]),
                Email = StringProperty.Create(orderProperties[2]),
                DealAddress = new Address
                {
                    Street = StringProperty.Create(orderProperties[3]),
                    City = StringProperty.Create(orderProperties[4]),
                    State = StringProperty.Create(orderProperties[5]),
                    ZipCode = StringProperty.Create(orderProperties[6])
                },
                CreditCard = StringProperty.Create(orderProperties[7])
            };
        }
    }
}
