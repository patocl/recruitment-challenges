using System;
using System.Linq;
using Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts;

namespace Refactoring.FraudDetection.Core.Infrastructure.Normalizer.CustomFormats
{
    public class EmailProperty : IPropertyBuilder<string>
    {
        public readonly char AtSymbol = '@';
        public readonly string AtSymbolString = "@";
        public readonly string PlusSymbol = "+";
        public readonly string DotSymbol = ".";
        public readonly string EmptyString = string.Empty;

        // TODO (HG) - Must to be clear the rules to build and validate the Mail, Review the Test Cases!
        public string Create(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            var countAtSymbols = value.Count(o => o == AtSymbol);

            if (countAtSymbols < 1)
                throw new ArgumentException("No Have At Symbol", nameof(value));
            if (countAtSymbols > 1)
                throw new ArgumentException("Have more than one At Symbol", nameof(value));

            var aux = value.Split(AtSymbol, StringSplitOptions.RemoveEmptyEntries);

            if (aux.Length != 2)
                throw new ArgumentException("not information provided after or before At Symbol", nameof(value));

            if (aux[0].Contains("+"))
                throw new ArgumentException("Can't have PlusSymbol before At Symbol", nameof(value));

            var atIndex = aux[0].IndexOf(PlusSymbol, StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(DotSymbol, EmptyString) : aux[0].Replace(DotSymbol, EmptyString).Remove(atIndex);

            return string.Join(AtSymbolString, new string[] { aux[0], aux[1] });
        }
    }
}
