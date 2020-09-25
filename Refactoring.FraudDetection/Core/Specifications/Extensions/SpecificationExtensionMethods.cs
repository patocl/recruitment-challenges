using Refactoring.FraudDetection.Core.Specifications.Contracts;

namespace Refactoring.FraudDetection.Core.Specifications.Extensions
{
    public static class SpecificationExtensionMethods
    {
        public static ISpecification<T> And<T>(this ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
            => new AndSpecification<T>(leftSpecification, rightSpecification);

        public static ISpecification<T> Or<T>(this ISpecification<T> leftSpecification, ISpecification<T> rightSpecification)
            => new AndSpecification<T>(leftSpecification, rightSpecification);

        public static ISpecification<T> Not<T>(this ISpecification<T> specification)
            => new NotSpecification<T>(specification);
    }
}
