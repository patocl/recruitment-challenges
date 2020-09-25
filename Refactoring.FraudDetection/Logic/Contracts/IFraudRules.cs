namespace Refactoring.FraudDetection.Logic.Contracts
{
    public interface IFraudRules<in T>
    {
        bool IsFraud(T order, T current);
    }
}