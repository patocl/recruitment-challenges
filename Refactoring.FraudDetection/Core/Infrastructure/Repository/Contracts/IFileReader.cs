namespace Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts
{
    public interface IFileReader
    {
        string Path { get; set; }

        string[] ReadAllLines();

        string ReadAllText();
    }
}
