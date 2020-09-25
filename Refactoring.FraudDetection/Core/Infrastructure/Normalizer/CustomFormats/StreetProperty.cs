using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;
using System;

namespace Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats
{
    public class StreetProperty : IPropertyBuilder<string>
    {
        public string Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            // TODO (HG) - Code smell here - Should be implemented better!
            return value
                .Replace("st.", "street")
                .Replace("rd.", "road"); ;
        }
    }
}