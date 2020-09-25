using System;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;

namespace Refactoring.FraudDetection.Core.Infrastructure.Builder.StandardFormats
{
    public class IntProperty : IPropertyBuilder<int>
    {
        public int Create(string propertySource)
        {
            if(string.IsNullOrEmpty(propertySource))
                throw new ArgumentNullException(nameof(propertySource));

            if (!int.TryParse(propertySource, out var result))
                throw new InvalidCastException(nameof(propertySource));

            return result;
        }
    }
}
