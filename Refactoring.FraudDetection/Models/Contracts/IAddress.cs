namespace Refactoring.FraudDetection.Models.Contracts
{
    public interface IAddress
    {
        string City { get; set; }
        string State { get; set; }
        string Street { get; set; }
        string ZipCode { get; set; }

        bool Equals(object obj);
        int GetHashCode();
    }
}