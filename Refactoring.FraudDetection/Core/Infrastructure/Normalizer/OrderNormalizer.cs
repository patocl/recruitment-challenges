using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using Refactoring.FraudDetection.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.Contracts;
using Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats;

namespace Refactoring.FraudDetection.Core.Infrastructure.Normalizer
{
    public class OrderNormalizer : INormalizer<IOrder>
    {
        public IPropertyBuilder<string> EmailBuilder { get; }
        public IPropertyBuilder<string> StreetBuilder { get; }
        public IPropertyBuilder<string> StateBuilder { get; }

        public OrderNormalizer()
        {
            EmailBuilder = new EmailProperty();
            StreetBuilder = new StreetProperty();
            StateBuilder = new StateProperty();
        }

        public OrderNormalizer(IPropertyBuilder<string> emailBuilder, IPropertyBuilder<string> streetBuilder, IPropertyBuilder<string> stateBuilder)
        {
            EmailBuilder = emailBuilder ?? throw new ArgumentNullException(nameof(emailBuilder));
            StreetBuilder = streetBuilder ?? throw new ArgumentNullException(nameof(streetBuilder));
            StateBuilder = stateBuilder ?? throw new ArgumentNullException(nameof(stateBuilder));
        }

        public IEnumerable<IOrder> Apply(IEnumerable<IOrder> orders)
        {
            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

            var normalizedOrders = orders.ToList();

            foreach (var order in normalizedOrders)
                Apply(order);

            return normalizedOrders;
        }

        public void Apply(IOrder entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            entity.Email = EmailBuilder.Create(entity.Email.ToLower());
            entity.DealAddress.Street = StreetBuilder.Create(entity.DealAddress.Street.ToLower());
            entity.DealAddress.City = entity.DealAddress.City.ToLower();
            entity.DealAddress.State = StateBuilder.Create(entity.DealAddress.State.ToLower());
        }
    }
}
