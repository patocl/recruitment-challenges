using System;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;

namespace Refactoring.FraudDetection.Core.Infrastructure.Builder.StandardFormats
{
    public class StringProperty : IPropertyBuilder<string>
    {
        public string Create(string propertySource)
        {
            if (string.IsNullOrEmpty(propertySource))
                throw new ArgumentNullException(nameof(propertySource));

            return propertySource;
        }
    }
}
