using Refactoring.FraudDetection.Core.Infrastructure.Repository.Contracts;
using System;
using System.IO;

namespace Refactoring.FraudDetection.Core.Infrastructure.Repository
{
    public class FileReader : IFileReader
    {
        public string Path { get; set; }

        public FileReader(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));

            Path = path;
        }

        public string[] ReadAllLines() => File.ReadAllLines(Path);

        public string ReadAllText() => File.ReadAllText(Path);
    }
}
