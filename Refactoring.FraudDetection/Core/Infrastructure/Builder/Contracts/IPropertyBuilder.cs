namespace Refactoring.FraudDetection.Core.Infrastructure.Builder.Contracts
{
    public interface IPropertyBuilder<out T>
    {
        T Create(string value);
    }
}
